```mermaid

---
config:
  layout: elk
---
erDiagram
    Roles {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код 
		(ADMIN, MANAGER, EMPLOYEE, HR)"
        VARCHAR(100) Name "Название"
        TEXT Description "Описание"
    }
    
    Users {
        SERIAL ID PK "Идентификатор"
        VARCHAR Username "Логин"
        VARCHAR Email "Электронная почта"
        INTEGER RoleID FK "Роль"
        INTEGER EmployeeID FK "Привязка к сотруднику 
		(если является сотрдуником)"
        BOOLEAN IsActive "Активен ли пользователь"
        TIMESTAMP CreatedAt "Дата создания"
    }

    Positions {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        TEXT Description "Описание"
    }
    
    Employees {
        SERIAL ID PK "Идентификатор"
        VARCHAR FirstName "Имя"
        VARCHAR LastName "Фамилия"
        VARCHAR MiddleName "Отчество"
        VARCHAR Email "Корпоративная почта"
        VARCHAR Phone "Телефон"
        DATE DateOfBirth "Дата рождения"
        DATE HireDate "Дата приема на работу"
        INTEGER PositionID FK "Должность"
        BOOLEAN IsActive "Активен ли в компании"
    }
    
    Departments {
        SERIAL ID PK "Идентификатор"
        INTEGER ParentID FK "Родительский отдел"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INTEGER ManagerID FK "Руководитель"
    }
    
    EmployeeDepartments {
        SERIAL ID PK "Идентификатор"
        INTEGER EmployeeID FK "Сотрудник"
        INTEGER DepartmentID FK "Отдел"
        INTEGER PositionID FK "Должность"
        DATE StartDate "Дата начала работы в отделе"
        DATE EndDate "Дата окончания работы в отделе"
        BOOLEAN IsPrimary "Основное место работы"
        TIMESTAMP CreatedAt "Дата создания записи"
    }
    
    Roles ||--o{ Users : "Roles.ID → Users.RoleID"
    Users ||--|| Employees : "Users.EmployeeID → Employees.ID"
    Positions ||--o{ Employees : "Positions.ID → Employees.PositionID"
    Positions ||--o{ EmployeeDepartments : "Positions.ID → EmployeeDepartments.PositionID"
    Employees ||--o{ EmployeeDepartments : "Employees.ID → EmployeeDepartments.EmployeeID"
    Departments ||--o{ EmployeeDepartments : "Departments.ID → EmployeeDepartments.DepartmentID"
    Departments ||--o{ Departments : "Departments.ID → Departments.ParentID"
    Departments ||--|| Employees : "Departments.ManagerID → Employees.ID"
