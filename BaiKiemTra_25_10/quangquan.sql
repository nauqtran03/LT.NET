create database quangquan
go
use quangquan

go
CREATE TABLE Employees (
    EmployeeID NVARCHAR(20) PRIMARY KEY,   -- Mã Nhân Viên
    FullName NVARCHAR(100) NOT NULL,            -- Họ và tên
    BirthYear DateTime,                               -- Năm sinh
    Gender NVARCHAR(10),                         -- Giới tính
    Department NVARCHAR(50),                     -- Bộ phận
    Position NVARCHAR(50),                       -- Chức vụ
    ContractType NVARCHAR(50),                   -- Hợp đồng
    Address NVARCHAR(200),                     -- Địa chỉ
	imgUrl VARCHAR(200)
);

go
INSERT INTO Employees (EmployeeID, FullName, BirthYear, Gender, Department, Position, ContractType, Address, imgUrl)
VALUES 
    ('001', N'Trần Quang Quân', '2003-11-16', N'Nam', N'IT', N'Nhân viên', N'Toàn thời gian', N'Hà Nội', 'D:\Pictures\anh_web\nhan_cap_3.png'),
    ('002', N'Nguyễn Văn Hướng', '2003-09-08', N'Nam', N'IT', N'Nhân Viên', N'Toàn thời gian', N'Bắc Ninh', 'D:\Pictures\anh_web\nhan_cap_2.png'),
    ('003', N'Lê Hoài Khiêm', '2003-12-07', N'Nam', N'IT', N'Nhân viên', N'Thử việc', N'Số 3, Đường GHI, Đà Nẵng', 'D:\Pictures\anh_web\nhan_cap_1.png'),
    
    