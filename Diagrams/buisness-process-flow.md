```mermaid

---
config:
  layout: dagre
---
flowchart TB
 subgraph s1["Легенда"]
    direction TB
        L1["Начало/Конец процесса"]
        L2["Действие"]
        L3{"Решение"}
        L4["Успешное завершение"]
        L5["Отклонение"]
        L6["Возврат на доработку"]
  end
    A(["Начало процесса"]) --> B{"Тип операции"}
    B -- Планирование на год --> C["Создание заявки Requests<br>OperationType: PLAN_YEAR"]
    B -- Новый отпуск --> D["Создание заявки Requests<br>OperationType: NEW_LEAVE"]
    B -- Перенос отпуска --> E["Выбор отпуска для переноса<br>OperationType: RESCHEDULE"]
    B -- Отмена отпуска --> F["Выбор отпуска для отмены<br>OperationType: CANCEL"]
    C --> G["Добавление отпусков Leaves в заявку<br>Статус Leaves: PLANNED"]
    D --> H["Добавление отпуска Leave в заявку<br>Статус Leave: PLANNED"]
    E --> I["Заполнение новых дат<br>Старый Leave: RESCHEDULED<br>Новый Leave: PLANNED"]
    F --> J["Указание причины отмены<br>Статус Leave: CANCELLED"]
    G --> K["Отправка на согласование<br>Статус Requests: PENDING_MANAGER"]
    H --> K
    I --> K
    J --> K
    K --> L["Этап 1: Согласование руководителем"]
    L --> M{"Решение руководителя"}
    M -- Согласовать --> N["Статус Requests: PENDING_HR<br>Передано в отдел кадров"]
    M -- Отклонить --> O["Статус Requests: REJECTED<br>Процесс завершен"]
    M -- Вернуть на доработку --> P["Статус Requests: SENT_BACK<br>Возврат инициатору"]
    P --> Q["Исправление заявки"]
    Q --> L
    N --> R{"Решение отдела кадров"}
    R -- Согласовать --> S["Статус Requests: APPROVED<br>Заявка согласована"]
    R -- Отклонить --> T["Статус Requests: REJECTED<br>Процесс завершен"]
    R -- Вернуть на доработку --> U["Статус Requests: SENT_BACK<br>Возврат инициатору"]
    U --> Q
    S --> V{"Тип операции"}
    V -- Планирование на год --> W["Обновление Leaves:<br>Статус PLANNED → APPROVED"]
    V -- Новый отпуск --> X["Обновление Leave:<br>Статус PLANNED → APPROVED<br>"]
    V -- Перенос --> Y["Обновление Leaves:<br>Старый: RESCHEDULED → CANCELLED<br>Новый: PLANNED → APPROVED<br>"]
    V -- Отмена --> Z["Обновление Leave:<br>Статус CANCELLED подтвержден<br>"]
    W --> AA(["Процесс завершен"])
    X --> AB(["Процесс завершен"])
    Y --> AC(["Процесс завершен"])
    Z --> AD(["Процесс завершен"])
    O --> AE(["Процесс завершен"])
    T --> AF(["Процесс завершен"])

     L1:::start
     L2:::action
     L3:::decision
     L4:::success
     L5:::reject
     L6:::rework
    classDef start fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef action fill:#f5f5f5,stroke:#616161,stroke-width:1px
    classDef decision fill:#fff3e0,stroke:#f57c00,stroke-width:2px
    classDef success fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px
    classDef reject fill:#ffebee,stroke:#c62828,stroke-width:2px
    classDef rework fill:#fff3e0,stroke:#ff8f00,stroke-width:2px
    style A fill:#e1f5fe
    style O fill:#ffebee
    style P fill:#fff3e0
    style S fill:#e8f5e8
    style T fill:#ffebee
    style U fill:#fff3e0
