CREATE TABLE loan_originators (
	id CHAR(36) PRIMARY KEY,
	name VARCHAR(MAX) NOT NULL,
);

CREATE TABLE loan_originator_branches (
	id CHAR(36) PRIMARY KEY,
	loan_originator_id CHAR(36) NOT NULL,
	name VARCHAR(MAX) NOT NULL,
	rating TINYINT NULL,
	country VARCHAR(MAX) NOT NULL,
	CONSTRAINT fk_loan_originators_loan_originator FOREIGN KEY (loan_originator_id) REFERENCES loan_originators (id)
);

CREATE TABLE loans (
	id CHAR(36) PRIMARY KEY,
	loan_originator_branch_id CHAR(36) NOT NULL,
	buyback BIT NOT NULL,
	closed_at DATETIME NULL,
	currency CHAR(3) NOT NULL,
	reference VARCHAR(MAX) NOT NULL,
	initial_amount DECIMAL(13,2) NOT NULL,
	initial_ltv DECIMAL(3, 0) NOT NULL,
	interest_rate DECIMAL (4,1) NOT NULL,
	issued_at DATETIME NOT NULL,
	listed_at DATETIME NOT NULL,
	ltv DECIMAL(3,0) NOT NULL,
	remaining_amount DECIMAL(13,2) NOT NULL,
	term INT NOT NULL,
	type TINYINT NOT NULL,
	CONSTRAINT fk_loan_originator_branches_loan_originator_branch FOREIGN KEY (loan_originator_branch_id) REFERENCES loan_originator_branches (id)
);