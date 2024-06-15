CREATE TABLE Categories (
  category_id INT IDENTITY(1, 1) PRIMARY KEY,
  name VARCHAR(50) UNIQUE NOT NULL,
  description TEXT
);

CREATE TABLE Expenses (
  expense_id INT IDENTITY(1, 1) PRIMARY KEY,
  user_id NVARCHAR(128),
  amount DECIMAL(10,2) NOT NULL,
  category_id INT,
  description TEXT,
  date DATE NOT NULL,
  created_at DATETIME DEFAULT GETDATE() NOT NULL
);


CREATE TABLE PaymentMethods (
  payment_method_id INT IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(50) UNIQUE NOT NULL,
  description TEXT
);

CREATE TABLE Budgets (
  budget_id INT IDENTITY(1,1) PRIMARY KEY,
  user_id NVARCHAR(128),
  category_id INT,
  amount DECIMAL(10,2) NOT NULL,
  start_date DATE NOT NULL,
  end_date DATE NOT NULL
);

CREATE TABLE RecurringExpenses (
  recurring_expense_id INT IDENTITY(1,1) PRIMARY KEY,
  user_id NVARCHAR(128),
  amount DECIMAL(10,2) NOT NULL,
  category_id INT,
  description TEXT,
  frequency VARCHAR(50),
  start_date DATE NOT NULL,
  end_date DATE
);


ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_Users FOREIGN KEY (user_id) REFERENCES AspNetUsers(id);

ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_Categories FOREIGN KEY (category_id) REFERENCES Categories(category_id);

ALTER TABLE Budgets
ADD CONSTRAINT FK_Budgets_Users FOREIGN KEY (user_id) REFERENCES AspNetUsers(id);

ALTER TABLE Budgets
ADD CONSTRAINT FK_Budgets_Categories FOREIGN KEY (category_id) REFERENCES Categories(category_id);

ALTER TABLE RecurringExpenses
ADD CONSTRAINT FK_RecurringExpenses_Users FOREIGN KEY (user_id) REFERENCES AspNetUsers(id);

ALTER TABLE RecurringExpenses
ADD CONSTRAINT FK_RecurringExpenses_Categories FOREIGN KEY (category_id) REFERENCES Categories(category_id);


/*After Creation*/

ALTER TABLE Expenses
ADD payment_method_id INT;

ALTER TABLE RecurringExpenses
ADD payment_method_id INT;

ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_PaymentMethods FOREIGN KEY (payment_method_id) REFERENCES PaymentMethods(payment_method_id);

ALTER TABLE RecurringExpenses
ADD CONSTRAINT FK_RecurringExpenses_PaymentMethods FOREIGN KEY (payment_method_id) REFERENCES PaymentMethods(payment_method_id);

