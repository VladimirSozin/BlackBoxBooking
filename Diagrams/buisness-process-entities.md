```mermaid

---
config:
  layout: elk
---
erDiagram
    LeaveTypes {
    }
    
    Employees {
    }
    
    Departments {
    }

     ApprovalTemplates {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        TEXT Description "Описание"
        INT SortOrder "Порядок сортировки"
    }
    
    ApprovalStages {
        SERIAL ID PK "Идентификатор"
        INT TemplateID FK "Шаблон"
        INT StageNumber "Номер этапа"
        INT RoleID FK "Роль согласующего"
        INT DepartmentID FK "Отдел согласующего"
        INT PositionID FK "Должность согласующего"
        VARCHAR StageName "Название этапа"
        INT TimeoutHours "Таймаут (часы)"
        BOOLEAN IsRequired "Обязательный этап"
    }
    
    Requests {
        SERIAL ID PK "Идентификатор"
        VARCHAR RequestNumber "Номер заявки"
        INT OperationTypeID FK "Тип операции"
        INT StatusID FK "Статус заявки"
        INT EmployeeID FK "Сотрудник"
        INT DepartmentID FK "Отдел"
        INT ApprovalTemplateID FK "Шаблон согласования"
        TEXT Comment "Комментарий"
        INT CurrentStageNumber "Текущий этап"
        TIMESTAMP SubmittedAt "Дата отправки"
        TIMESTAMP CompletedAt "Дата завершения"
    }
    
    Leaves {
        SERIAL ID PK "Идентификатор"
        INT RequestID FK "Заявка"
        INT EmployeeID FK "Сотрудник"
        INT LeaveTypeID FK "Тип"
        INT StatusID FK "Статус отпуска"
        DATE StartDate "Дата начала"
        DATE EndDate "Дата окончания"
        DECIMAL DurationDays "Количество дней"
        INT PreviousLeaveID FK "Предыдущая версия"
        TEXT Comment "Комментарий"
    }
    
    ApprovalHistory {
        SERIAL ID PK "Идентификатор"
        INT RequestID FK "Заявка"
        INT StageNumber "Номер этапа"
        INT ApproverID FK "Согласующий (UserID)"
        INT DecisionID FK "Решение"
        TIMESTAMP DecisionDate "Дата решения"
        TEXT Comment "Комментарий"
        INT NextStageNumber "Следующий этап"
    }

    OperationType {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT SortOrder "Порядок"
    }

    RequestStatus {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT SortOrder "Порядок"
    }

    LeaveStatus {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        INT SortOrder "Порядок"
    }

    DecisionType {
        SERIAL ID PK "Идентификатор"
        VARCHAR Code "Код"
        VARCHAR Name "Название"
        BOOLEAN IsFinal "Финальное решение"
        INT SortOrder "Порядок"
    }

    Requests ||--o{ Leaves : "Requests.ID → Leaves.RequestID"
    Requests ||--o{ ApprovalHistory : "Requests.ID → ApprovalHistory.RequestID"
    Leaves ||--o{ Leaves : "Leaves.ID → Leaves.PreviousLeaveID"
    
    ApprovalTemplates ||--o{ ApprovalStages : "ApprovalTemplates.ID → ApprovalStages.TemplateID"
    ApprovalTemplates ||--o{ Requests : "ApprovalTemplates.ID → Requests.ApprovalTemplateID"
    
    OperationType ||--o{ Requests : "OperationType.ID → Requests.OperationTypeID"
    RequestStatus ||--o{ Requests : "RequestStatus.ID → Requests.StatusID"
    LeaveStatus ||--o{ Leaves : "LeaveStatus.ID → Leaves.StatusID"
    DecisionType ||--o{ ApprovalHistory : "DecisionType.ID → ApprovalHistory.DecisionID"

    Employees ||--o{ Requests : "Employees.ID → Requests.EmployeeID"
    Employees ||--o{ Leaves : "Employees.ID → Leaves.EmployeeID"
    Departments ||--o{ Requests : "Departments.ID → Requests.DepartmentID"
    LeaveTypes ||--o{ Leaves : "LeaveTypes.ID → Leaves.LeaveTypeID"
