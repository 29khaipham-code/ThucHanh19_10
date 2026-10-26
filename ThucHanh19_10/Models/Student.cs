using System.ComponentModel.DataAnnotations; 

namespace ThucHanh19_10.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên bắt buộc phải nhập.")]
        [StringLength(100,MinimumLength =4)]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Emaill bat buoc phai dc nhap")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        [RegularExpression(@"[A-Za-z0-9.%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Email không đúng định dạng!")]
        public string? Email { get; set; }
        [StringLength(100,MinimumLength =8)]
        [Required(ErrorMessage ="Mat khau bat buoc phai dc nhap")]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Nganh bat buoc phai dc chon")]
        public Branch? Branch { get; set; }
        [Required(ErrorMessage ="Gioi tinh bat buoc phai duoc chon")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Dia chi bat buoc phai dc nhap!")]
        public string? Address { get; set; }

        [Range(typeof(DateTime) , "1/1/1963","12/31/2026")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage ="Ngay sinh bat buoc phai duoc nhap")]
        public DateTime DateOfBorth { get; set; }
        [Required(ErrorMessage ="Diem bat buoc phai dc nhap")]
        [Range(0.0 , 10.0,ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0!")]
        public double? diem { set; get; }
    }
}
