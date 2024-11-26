using FADemo.Models.Organization;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FADemo.Models.BaseInformation.InitDate
{
    /// <summary>
    /// Data seed数据，也可以在EF迁移中填充，参阅:https://learn.microsoft.com/zh-cn/ef/core/modeling/data-seeding
    /// </summary>
    public class BaseInit
    {
        public static void InitBaseData(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (context == null)
            {
                throw new NullReferenceException();
            }
            if (context.AssetAlterModes.Count()==0)
            {
                context.AssetAlterModes.AddRange(
                    new AssetAlterMode
                    {
                        AssetAlterName = "BuyIn",
                        AssetAlterDescription = "BuyIn",
                        IsDisabled = false,
                        IsAdd = true
                    },
                    new AssetAlterMode
                    {
                        AssetAlterName = "Build",
                        AssetAlterDescription = "Build",
                        IsDisabled = false,
                        IsAdd = true
                    },
                    new AssetAlterMode
                    {
                        AssetAlterName = "Profit",
                        AssetAlterDescription = "Profit",
                        IsDisabled = false,
                        IsAdd = true
                    },
                    new AssetAlterMode
                    {
                        AssetAlterName = "Loss",
                        AssetAlterDescription = "Loss",
                        IsDisabled = false,
                        IsAdd = false
                    },
                    new AssetAlterMode
                    {
                        AssetAlterName = "Damage",
                        AssetAlterDescription = "Damage",
                        IsDisabled = false,
                        IsAdd = false
                    },
                    new AssetAlterMode
                    {
                        AssetAlterName = "Sale",
                        AssetAlterDescription = "Sale",
                        IsDisabled = false,
                        IsAdd = false
                    });
            }
            if (context.AssetDeprmetHods.Count() == 0) 
            {
                context.AssetDeprmetHods.AddRange(
                    new AssetDeprmetHod
                    {
                        AssetDeprmetName= "Averaging of years",
                        AssetDeprmetDescription= "Averaging of years",
                        AssetDeproption= (char?)1,
                        IsDisabled=false,
                    });
            }
            if (context.AssetPositions.Count() == 0)
            { 
                context.AssetPositions.AddRange(
                    new AssetPosition
                    {
                        AssetPositionName="Office",
                        AssetPositionDescription= "Office",
                    },
                    new AssetPosition
                    {
                        AssetPositionName = "Workshop",
                        AssetPositionDescription = "Workshop",
                    },
                    new AssetPosition
                    {
                        AssetPositionName = "Warehouse",
                        AssetPositionDescription = "Warehouse",
                    });
            }
            if(context.AssetStatuses.Count() == 0)
            {
                context.AssetStatuses.AddRange(
                    new AssetStatus
                    {
                        AssetStatusNumber= "101",
                        AssetStatusName= "Normal",
                        AssetStatusDescription= "Normal",
                        CreateDatetime=DateTime.Now,
                        IsDisabled=false
                    },
                    new AssetStatus
                    {
                        AssetStatusNumber = "102",
                        AssetStatusName = "Maintenance",
                        AssetStatusDescription = "Maintenance",
                        CreateDatetime = DateTime.Now,
                        IsDisabled = false
                    },
                    new AssetStatus
                    {
                        AssetStatusNumber = "103",
                        AssetStatusName = "scrap",
                        AssetStatusDescription = "scrap",
                        CreateDatetime = DateTime.Now,
                        IsDisabled = false
                    },
                     new AssetStatus
                     {
                         AssetStatusNumber = "104",
                         AssetStatusName = "other",
                         AssetStatusDescription = "other",
                         CreateDatetime = DateTime.Now,
                         IsDisabled = false
                     });
            }
            if(context.AssetTypes.Count() == 0)
            {
                context.AssetTypes.AddRange(
                    new AssetType
                    {
                        AssetTypeNumber= "A01010000",
                        AssetTypeName="Building",
                        AssetTypeCreateDatetime=DateTime.Now,
                        AssetTypeDescription= "Building",
                        AssetTypeIsDisabled=false
                    },
                    new AssetType
                    {
                        AssetTypeNumber = "A02020000",
                        AssetTypeName = "Office equipment",
                        AssetTypeCreateDatetime = DateTime.Now,
                        AssetTypeDescription = "Office equipment",
                        AssetTypeIsDisabled = false
                    },
                    new AssetType
                    {
                        AssetTypeNumber = "A04040000",
                        AssetTypeName = "Archives",
                        AssetTypeCreateDatetime = DateTime.Now,
                        AssetTypeDescription = "Archives",
                        AssetTypeIsDisabled = false
                    });
            }
            if(context.Departments.Count() == 0)
            {
                context.Departments.AddRange(
                    new Department
                    {
                        DepartmentNumber="1001",
                        DepartmentName= "General Department",
                        CreateDatetime=DateTime.Now,
                    },
                    new Department
                    {
                        DepartmentNumber = "1002",
                        DepartmentName = "Finance Department",
                        CreateDatetime = DateTime.Now,
                    },
                    new Department
                    {
                        DepartmentNumber = "1003",
                        DepartmentName = "Research and Development Department",
                        CreateDatetime = DateTime.Now,
                    },
                    new Department
                    {
                        DepartmentNumber = "1004",
                        DepartmentName = "Production Center",
                        CreateDatetime = DateTime.Now,
                    },
                    new Department
                    {
                        DepartmentNumber = "1005",
                        DepartmentName = "Sales Department",
                        CreateDatetime = DateTime.Now,
                    });
            }
            if (context.Employees.Count() == 0)
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        EmployeeNumber="1001",
                        EmployeeName="emp1",
                        Position="??Manager",
                        CreateDatetime=DateTime.Now,
                        DepartmentId = 1
                    }, 
                    new Employee
                    {
                        EmployeeNumber = "1002",
                        EmployeeName = "emp2",
                        Position = "Operator",
                        CreateDatetime = DateTime.Now,
                        DepartmentId = 2
                    },
                    new Employee
                    {
                        EmployeeNumber = "1003",
                        EmployeeName = "emp3",
                        Position = "Operator",
                        CreateDatetime = DateTime.Now,
                        DepartmentId = 3
                    },
                    new Employee
                    {
                        EmployeeNumber = "1004",
                        EmployeeName = "emp4",
                        Position = "Office",
                        CreateDatetime = DateTime.Now,
                        DepartmentId = 4
                    },
                    new Employee
                    {
                        EmployeeNumber = "1005",
                        EmployeeName = "emp5",
                        Position = "Office",
                        CreateDatetime = DateTime.Now,
                        DepartmentId = 5
                    }
                    );
            }
            context.SaveChanges();
        }
    }
}
