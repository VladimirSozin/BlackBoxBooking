```mermaid

---
config:
  layout: elk
---
erDiagram
    LeaveTypes {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        BOOLEAN IsPaid "Оплачиваемый"
        BOOLEAN AffectsBalance "Влияет на баланс"
        TEXT Description "Описание"
    }

    ApprovalTemplates {
        SERIAL ID PK "Идентификатор"
        VARCHAR Name "Название"
        VARCHAR Code "Код"
        TEXT Description "Описание"
        TIMESTAMP CreatedAt "Дата создания"
        INTEGER CreatedBy FK "Кто создал"
    }
    
    ApprovalStages {
        SERIAL ID PK "Идентификатор"
        INTEGER TemplateID FK "Шаблон"
        INTEGER StageNumber "Номер этапа"
        INTEGER RoleID FK "Роль согласующего"
        VARCHAR StageName "Название"
        TIMESTAMP CreatedAt "Дата создания"
    }
    
    Requests {
        SERIAL ID PK "Идентификатор"
        VARCHAR RequestNumber "Номер заявки"
        VARCHAR OperationType "Тип операции
        ( PLAN_YEAR, NEW_LEAVE, 
        RESCHEDULE, CANCEL)"
        VARCHAR Status "Статус заявки
        (DRAFT, PENDING_MANAGER, 
        PENDING_HR, APPROVED, REJECTED, SENT_BACK)"
        INTEGER EmployeeID FK "Сотрудник"
        INTEGER DepartmentID FK "Отдел"
        INTEGER TargetLeaveID FK "Целевой отпуск
        (при переносе или отмене)"
        TEXT Comment "Комментарий"
        INTEGER TemplateID FK "Шаблон согласования"
        INTEGER CurrentStage "Текущий этап"
        INTEGER CreatedBy FK "Инициатор"
        TIMESTAMP CreatedAt "Дата создания"
        TIMESTAMP UpdatedAt "Дата обновления"
    }
    
    Leaves {
        SERIAL ID PK "Идентификатор"
        INTEGER EmployeeID FK "Сотрудник"
        INTEGER LeaveTypeID FK "Тип"
        DATE StartDate "Дата начала"
        DATE EndDate "Дата окончания"
        DECIMAL DurationDays "Количество дней"
        VARCHAR Status "Статус (
        PLANNED, APPROVED, USED, 
        CANCELLED, RESCHEDULED)"
        INTEGER RequestID FK "Родительская заявка"
        INTEGER PreviousLeaveID FK "Предыдущая версия 
        (при переносе)"
        TIMESTAMP CreatedAt "Дата создания"
        TIMESTAMP UpdatedAt "Дата обновления"
    }
    
    ApprovalHistory {
        SERIAL ID PK "Идентификатор"
        INTEGER RequestID FK "Заявка"
        INTEGER StageNumber "Номер этапа"
        INTEGER ApproverID FK "Согласующий"
        VARCHAR Decision "Решение"
        TIMESTAMP DecisionDate "Дата решения"
        TEXT Comment "Комментарий"
        INTEGER NextStage "Следующий этап"
    }

    LeaveBalances {
        SERIAL ID PK "Идентификатор"
        INTEGER EmployeeID FK "Сотрудник"
        INTEGER LeaveTypeID FK "Тип отпуска"
        INTEGER Year "Год"
        DECIMAL CurrentBalance "Текущий остаток"
    }
    
    BalanceTransactions {
        SERIAL ID PK "Идентификатор"
        INTEGER EmployeeID FK "Сотрудник"
        INTEGER LeaveTypeID FK "Тип отпуска"
        DATE TransactionDate "Дата транзакции"
        VARCHAR TransactionType "Тип транзакции(
        EARN, USE, RETURN, MANUAL)"
        DECIMAL Amount "Количество дней"
        INTEGER LeaveID FK "Связанный отпуск"
        INTEGER RequestID FK "Связанная заявка"
        TEXT Description "Описание операции"
        INTEGER CreatedBy FK "Кто создал транзакцию"
        TIMESTAMP CreatedAt "Дата создания"
    }
    
    Requests ||--o{ Leaves : "Requests.ID → Leaves.RequestID"
    Requests ||--o{ ApprovalHistory : "Requests.ID → ApprovalHistory.RequestID"
    Requests ||--o{ BalanceTransactions : "Requests.ID → BalanceTransactions.RequestID"
    Leaves ||--o{ Leaves : "Leaves.ID → Leaves.PreviousLeaveID"
    Leaves ||--o{ BalanceTransactions : "Leaves.ID → BalanceTransactions.LeaveID"
    
    Employees ||--o{ Requests : "Employees.ID → Requests.EmployeeID"
    Employees ||--o{ Leaves : "Employees.ID → Leaves.EmployeeID"
    Employees ||--o{ LeaveBalances : "Employees.ID → LeaveBalances.EmployeeID"
    
    Departments ||--o{ Requests : "Departments.ID → Requests.DepartmentID"
    
    LeaveTypes ||--o{ Leaves : "LeaveTypes.ID → Leaves.LeaveTypeID"
    LeaveTypes ||--o{ LeaveBalances : "LeaveTypes.ID → LeaveBalances.LeaveTypeID"
    
    ApprovalTemplates ||--o{ ApprovalStages : "ApprovalTemplates.ID → ApprovalStages.TemplateID"
    ApprovalTemplates ||--o{ Requests : "ApprovalTemplates.ID → Requests.TemplateID"
