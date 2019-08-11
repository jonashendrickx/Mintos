using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Mintos.Converters;
using Mintos.Plugins.Readers.MicrosoftOffice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mintos.Plugins.LoanBook
{
    public class LoanBookReader : ILoanBookReader
    {
        public IEnumerable<LoanInformation> Read(string file)
        {
            using (var doc = SpreadsheetDocument.Open(file, false))
            {
                var workbookPart = doc.WorkbookPart;
                var worksheetPart = workbookPart.WorksheetParts.First();
                var reader = OpenXmlReader.Create(worksheetPart);

                bool isFirst = true;
                while (reader.Read())
                {
                    if (reader.ElementType == typeof(Row))
                    {
                        if (reader.IsEndElement) continue;
                        if (isFirst)
                        {
                            isFirst = false;
                            continue;
                        }

                        var children = reader.LoadCurrentElement().ChildElements;

                        var loan = new LoanInformation();
                       
                        foreach (Cell child in children.Where(x => x is Cell))
                        {
                            var columnReference = Regex.Replace(child.CellReference.ToString(), @"[\d]", string.Empty);
                            var cellContent = child.InnerText;
                            switch (columnReference)
                            {
                                case "A":
                                    loan.Id = cellContent;
                                    continue;
                                case "B":
                                    loan.IssueDate = StringToDateTimeConverter.Convert(cellContent);
                                    continue;
                                case "C":
                                    loan.ClosingDate = StringToDateTimeConverter.Convert(cellContent);
                                    continue;
                                case "D":
                                    loan.ListingDate = StringToDateTimeConverter.Convert(cellContent);
                                    continue;
                                case "E":
                                    loan.Country = cellContent;
                                    continue;
                                case "F":
                                    loan.LoanOriginator = cellContent;
                                    continue;
                                case "G":
                                    loan.MintosRating = cellContent;
                                    continue;
                                case "H":
                                    loan.LoanType = cellContent;
                                    continue;
                                case "I":
                                    loan.LoanRate = Convert.ToDecimal(cellContent);
                                    continue;
                                case "J":
                                    loan.Term = Convert.ToUInt16(cellContent);
                                    continue;
                                case "K":
                                    loan.Collateral = YesNoToBooleanConverter.Convert(cellContent);
                                    continue;
                                case "L":
                                    loan.InitialLtv = Convert.ToDecimal(cellContent);
                                    continue;
                                case "M":
                                    loan.Ltv = Convert.ToDecimal(cellContent);
                                    continue;
                                case "N":
                                    loan.LoanStatus = cellContent;
                                    continue;
                                case "O":
                                    loan.BuybackReason = cellContent;
                                    continue;
                                case "P":
                                    loan.InitialLoanAmount = Convert.ToDecimal(cellContent);
                                    continue;
                                case "Q":
                                    loan.RemainingLoanAmount = Convert.ToDecimal(cellContent);
                                    continue;
                                case "R":
                                    loan.Currency = cellContent;
                                    continue;
                                case "S":
                                    loan.Buyback = YesNoToBooleanConverter.Convert(cellContent);
                                    continue;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(columnReference));
                            }
                        }
                        yield return loan;
                    }
                }
            }
        }
    }
}
