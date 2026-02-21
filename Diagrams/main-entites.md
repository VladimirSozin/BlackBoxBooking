```mermaid

---
config:
  layout: elk
---
erDiagram
    Roles {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        TEXT Description "Описание"
        INT SortOrder "Порядок сортировки"
    }
    
    Users {
        SERIAL ID PK "Идентификатор"
        VARCHAR Username "Логин"
        VARCHAR Email "Email"
        VARCHAR FirstName "Имя"
        VARCHAR LastName "Фамилия"
        VARCHAR MiddleName "Отчество"
        VARCHAR Phone "Телефон"
        DATE DateOfBirth "Дата рождения"
        INT RoleID FK "Роль"
        INT EmployeeID FK "Сотрудник"
        BOOLEAN IsEmployee "Является сотрудником"
        TIMESTAMP LastLoginAt "Последний вход"
    }

    Positions {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT Grade "Грейд"
        TEXT Description "Описание"
    }
    
    Employees {
        SERIAL ID PK "Идентификатор"
        VARCHAR EmployeeNumber "Табельный номер"
        DATE HireDate "Дата приема"
        DATE TerminationDate "Дата увольнения"
        INT ManagerID FK "Руководитель"
        BOOLEAN HasUserAccount "Есть учетная запись"
        BOOLEAN IsActive "Активен"
    }
    
    Departments {
        SERIAL ID PK "Идентификатор"
        INT ParentID FK "Родительский отдел"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT ManagerID FK "Руководитель"
    }
    
    EmployeeDepartments {
        SERIAL ID PK "Идентификатор"
        INT EmployeeID FK "Сотрудник"
        INT DepartmentID FK "Отдел"
        INT PositionID FK "Должность"
        DATE StartDate "Дата начала"
        DATE EndDate "Дата окончания"
        BOOLEAN IsPrimary "Основное место"
        DECIMAL FTE "Ставка"
    }

    LeaveTypes {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        BOOLEAN IsPaid "Оплачиваемый"
        BOOLEAN AffectsBalance "Влияет на баланс"
        INT MinDays "Мин. длительность"
        INT MaxDays "Макс. длительность"
        DECIMAL AccrualRate "Норма начисления"
        INT SortOrder "Порядок"
    }

    LeaveBalances {
        SERIAL ID PK "Идентификатор"
        INT EmployeeID FK "Сотрудник"
        INT LeaveTypeID FK "Тип отпуска"
        INT Year "Год"
        DECIMAL Entitled "Начислено"
        DECIMAL Used "Использовано"
        DECIMAL Planned "Запланировано"
        DECIMAL Available "Доступно"
        TIMESTAMP CalculatedAt "Дата расчета"
    }
    
    BalanceTransactions {
        SERIAL ID PK "Идентификатор"
        INT EmployeeID FK "Сотрудник"
        INT LeaveTypeID FK "Тип отпуска"
        INT TransactionTypeID FK "Тип транзакции"
        TIMESTAMP TransactionDate "Дата"
        DECIMAL Amount "Сумма"
        INT LeaveID FK "Связанный отпуск"
        INT RequestID FK "Связанная заявка"
        TEXT Description "Описание"
    }

    TransactionType {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        VARCHAR Sign "Знак"
        INT SortOrder "Порядок"
    }

    Roles ||--o{ Users : "Roles.ID → Users.RoleID"
    Users ||--o| Employees : "Users.EmployeeID → Employees.ID"
    
    Employees ||--o{ Employees : "Employees.ID → Employees.ManagerID"
    Employees ||--o{ EmployeeDepartments : "Employees.ID → EmployeeDepartments.EmployeeID"
    Employees ||--o{ Departments : "Employees.ID → Departments.ManagerID"
    Employees ||--o{ LeaveBalances : "Employees.ID → LeaveBalances.EmployeeID"
    Employees ||--o{ BalanceTransactions : "Employees.ID → BalanceTransactions.EmployeeID"
    
    Departments ||--o{ Departments : "Departments.ID → Departments.ParentID"
    Departments ||--o{ EmployeeDepartments : "Departments.ID → EmployeeDepartments.DepartmentID"
    
    Positions ||--o{ EmployeeDepartments : "Positions.ID → EmployeeDepartments.PositionID"
    
    LeaveTypes ||--o{ LeaveBalances : "LeaveTypes.ID → LeaveBalances.LeaveTypeID"
    LeaveTypes ||--o{ BalanceTransactions : "LeaveTypes.ID → BalanceTransactions.LeaveTypeID"
    
    TransactionType ||--o{ BalanceTransactions : "TransactionType.ID → BalanceTransactions.TransactionTypeID"

    %% Связи с бизнес-процессом
    Requests ||--o{ BalanceTransactions : "Requests.ID → BalanceTransactions.RequestID"
    Leaves ||--o{ BalanceTransactions : "Leaves.ID → BalanceTransactions.LeaveID"
