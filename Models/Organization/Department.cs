using FADemo.Models.FixedAsset;

namespace FADemo.Models.Organization
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentNumber { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreateDatetime { get; set; }

        public List<Employee>? Employees { get; set; }

        public List<AssetCreateBase>? AssetCreateBase { get; set; }

        public List<AssetUpdateDetail>? AssetUpdateDetail { get; set; }
    }
}
