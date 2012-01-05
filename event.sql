use EventStore

create table Events
(
  [Id] uniqueidentifier not null,
  [DateTime] datetime not null default getdate(),
  [AggregateRootId] uniqueidentifier not null,
  [Event] varbinary(max) not null
)
