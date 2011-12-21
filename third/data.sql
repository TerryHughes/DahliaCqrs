use DataStore
go

select * from retreats

truncate table retreats
insert into retreats values ('1E4DC51C-107F-4523-93C4-AAB033ADC7DF',DATEADD(dd,-1,GETDATE()),'dumps like a truck')
insert into retreats values ('B22F809E-1A82-4747-9420-45165C2C3992',DATEADD(dd,1,GETDATE()),'baby move your butt')
insert into retreats values ('98EFAD72-5A47-434A-AD4C-BB1269C2C292',DATEADD(dd,0,GETDATE()),'thighs like what')
