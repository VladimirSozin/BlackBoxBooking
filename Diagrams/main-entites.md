```mermaid

---
config:
  layout: elk
---
erDiagram
    Role {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код (ADMIN, MANAGER, HR, EMPLOYEE)"
        VARCHAR Name "Название"
        TEXT Description "Описание"
        INT SortOrder "Порядок сортировки"
    }
    
    User {
        SERIAL ID PK "Идентификатор"
        VARCHAR Username "Логин (уникальный)"
        VARCHAR Email "Электронная почта (уникальная)"
        VARCHAR FirstName "Имя"
        VARCHAR LastName "Фамилия"
        VARCHAR MiddleName "Отчество"
        VARCHAR Phone "Телефон"
        DATE DateOfBirth "Дата рождения"
        INT RoleID FK "Роль"
        INT EmployeeID FK "Привязка к сотруднику (уникальная)"
        BOOLEAN IsEmployee "Является сотрудником"
        TIMESTAMP LastLoginAt "Последний вход"
        TIMESTAMP CreatedAt "Дата создания"
    }

    Position {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT Grade "Грейд"
        TEXT Description "Описание"
    }
    
    Employee {
        SERIAL ID PK "Идентификатор"
        VARCHAR EmployeeNumber "Табельный номер (уникальный)"
        DATE HireDate "Дата приема на работу"
        DATE TerminationDate "Дата увольнения"
        INT ManagerId FK "Руководитель (Employee.ID)"
        BOOLEAN HasUserAccount "Есть учетная запись"
        BOOLEAN IsActive "Активен в компании"
    }
    
    Department {
        SERIAL ID PK "Идентификатор"
        INT ParentId FK "Родительский отдел"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT ManagerId FK "Руководитель (Employee.ID)"
    }
    
    EmployeeDepartment {
        SERIAL ID PK "Идентификатор"
        INT EmployeeId FK "Сотрудник"
        INT DepartmentId FK "Отдел"
        INT PositionId FK "Должность"
        DATE StartDate "Дата начала"
        DATE EndDate "Дата окончания"
        BOOLEAN IsPrimary "Основное место работы"
        DECIMAL FTE "Ставка (Full-Time Equivalent)"
    }
    
    Role ||--o{ User : "Role.ID → User.RoleID"
    User ||--o| Employee : "User.EmployeeID → Employee.ID"
    
    Employee ||--o{ Employee : "Employee.ID → Employee.ManagerId"
    Employee ||--o{ EmployeeDepartment : "Employee.ID → EmployeeDepartment.EmployeeId"
    Employee ||--o{ Department : "Employee.ID → Department.ManagerId"
    
    Department ||--o{ Department : "Department.ID → Department.ParentId"
    Department ||--o{ EmployeeDepartment : "Department.ID → EmployeeDepartment.DepartmentId"
    
    Position ||--o{ EmployeeDepartment : "Position.ID → EmployeeDepartment.PositionId"
