  create table departments(department_id integer primary key,
		   depname varchar(40) not null,
		   mgrid char(10),
		   location_id integer)

CREATE TABLE employees
    ( employee_id    integer constraint myemployees_pk PRIMARY KEY
    , first_name     VARCHAR(20)
    , last_name      VARCHAR(25) NOT NULL
    , email          VARCHAR(25) NOT NULL UNIQUE
    , phone_number   VARCHAR(20)
    , hire_date      DATETIME NOT NULL check(hire_date<getdate())
    , job_id         VARCHAR(10) NOT NULL
    , salary         integer CHECK (salary>0)
    , commission_pct integer
    , manager_id     integer REFERENCES	 employees (employee_id)
    , department_id  integer REFERENCES  departments (department_id));

	sp_help myemployees_pk

	alter table employees_c drop constraint myemployees_pk
	insert into employees values(1003,'Akhil','V','Akilv@gmail.com','9444077777','01/23/2018','IT',40000,null,null,1)
		   select * from departments
		   drop table employees
		   drop table departments
		 
		   select * from departments
		   insert into departments values(2,'QUALITY','E001',200)



		   delete departments where department_id=2

		   
		   select employee_id,first_name,last_name into emp_wdnames from employees where department_id=1
		   select * from employees_wd

		   sp_help PK__account__AF91A6ACD75D3121
		   alter table departments


		   update employees set manager_id=1004 where employee_id=1001
		   
		   select @@servername
		   print @@VERSION

		   declare @myname varchar(50)
		   declare @marks integer
		   select @myname='Kavin Kumar',@marks=85
		   print 'My Name is : ' + @myname + 'Marks is :' + convert(varchar,@marks+10)

		   create proc myproc @var1 integer,@var2 integer
		   as
				select @var1+@var2
				

alter proc updatesal @raisesal integer,@deptno integer,@result integer output as
update emp set sal=sal+(sal*@raisesal/100) where deptno=@deptno
select @result=@@ROWCOUNT


declare @outvar integer
exec updatesal 10,30,@outvar output

print 'The total no of employees updated is : ' + convert(varchar,@outvar)

sp_helptext updatesal

create function displayemp() returns integer
as
begin
select * from emp

end
 
CREATE FUNCTION check_sal RETURN integer as
@v_dept_id integer
 BEGIN
@v_sal integer
 SELECT @v_sal=avg(sal) from emp where deptno=@v_dept_id
  IF @v_sal > 0
  RETURN @v_sal
 ELSE
  RETURN 0 

CREATE FUNCTION SalAmount (@dep_id integer ) 
  RETURNS MONEY 
  AS 
  BEGIN 
      DECLARE @totamt MONEY 
        SELECT @totamt = SUM(sal) 
          FROM emp 
        WHERE deptno = @dep_id 
      RETURN(@totamt) 
  END 
declare @amt money
exec @amt=SalAmount 50 
print @amt

select max(sal) from emp where deptno=10


begin transaction tr1
sp_helpindex employees
update emp set sal=sal+(sal*10/100) where deptno=10
if(select max(sal) from emp where deptno=10)>7500
begin
rollback transaction
print 'Updation failed'
end
else
begin
commit transaction
print 'Completed Updation Succcesfully'
end
end



alter trigger demotrigger
on dept
for insert
as
if(select count(*) from dept d,inserted i where d.dname=i.dname)=1
begin
	print 'Insert trigger of dept table is called'
	commit tran
end
else
begin
	print 'This dept name already exists'
	rollback tran
end
select * from dept
insert into dept values(104,'Finance','Chennai',null,12324)

select * from employees
alter trigger trgempdel on employees for delete
as
begin
if(select count(*) from deleted where commission_pct is null)=0
begin
print 'Cannot delete....Its too early to quit'
rollback
end
else
print 'Best of Luck in your new organization'
end
insert into employees values('1005','Kanav','Kumar','kanav@gmail.com',null,'01/01/2018','IT',10000,10,null,1)
delete employees where employee_id='1005'








 
 sp_helpindex employees





		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   select * from emp
		   select * from emp where (sal,deptno) in 
		   (select sal,deptno from emp where sal between 1000 and 2000
		    )
			select * from emp

			select empno,sal,deptno from emp e1
			where sal>(select avg(sal) from emp e2 
			where e2.deptno=e1.deptno)


create view empsal30
as
select empno,ename,sal,deptno from emp where deptno=30

select * from empsal30
select * from emp
select * from empsal30
delete from emp where deptno=30
update empsal30 set sal=sal+(sal*20/100)

sp_help empsal30
sp_helptext empsal30
sp_help syscomments
select * from sysobjects
select * from syscolumns
select * from sysdepends
select ctext from syscomments

alter view empsal30
as
select * from emp where deptno=30

select * from emp
select * from empsal30

insert into empsal30 values('7001','KANAV','KUMAR',null,7902,getdate(),1000,50)

update empsal30
set deptno=30

select * from dept
sp_helptext empdept
alter view empdept
with encryption
as
select empno,ename,job,e.deptno,dname,loc from emp e,dept d where e.deptno=d.deptno

sp_help

select * from emp_personal


drop index PK__employee__AF4CE865755FE7D1 on employee
sp_help employees
alter view emp_personal as select * from employees where first_name like 'A%'
create index lastname_indx on employees(last_name)
drop index lastname_indx on employees