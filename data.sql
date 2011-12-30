use DataStore

drop table Retreats
create table Retreats
(
    [Id] uniqueidentifier not null,
    [Date] datetime not null,
    [Description] varchar(100)
)

drop table ProcessedCommands
create table ProcessedCommands
(
    [Id] uniqueidentifier not null,
    [Date] datetime not null default getdate()
)

--select * from retreats
--select * from processedcommands

insert into retreats values ('1E4DC51C-107F-4523-93C4-AAB033ADC7DF',DATEADD(dd,-3,GETDATE()),'dumps like a truck')
insert into retreats values ('B22F809E-1A82-4747-9420-45165C2C3992',DATEADD(dd,-1,GETDATE()),'baby move your butt')
insert into retreats values ('98EFAD72-5A47-434A-AD4C-BB1269C2C292',DATEADD(dd,-2,GETDATE()),'thighs like what')

insert into retreats values ('AB121975-75B1-4B94-93AD-0B533A575E98','12/20/2011','the end of the world ... of warcraft')
insert into retreats values ('451FE4D8-CC40-4446-9D7A-E0CA7B209C88','12/21/2012','simply the start of the next b''ak''tun')
insert into retreats values ('AF3521BC-374A-4722-87A6-C3928251CE2B','12/31/1999','it''s the final countdown')
