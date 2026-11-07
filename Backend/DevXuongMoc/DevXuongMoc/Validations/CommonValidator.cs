namespace DevXuongMoc.Validations
{
    public static class CommonValidator
    {
        /// <summary>
        /// Không được để trống.
        /// </summary>
        /// <param name="nameValid">Tên trường hiển thị trong thông báo, ví dụ "Họ tên"</param>
        /// <param name="value">Giá trị truyền từ ngoài vào</param>
        /// <returns>Thông báo lỗi; null nếu hợp lệ</returns>
        public static string? NotBlank(string nameValid, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return $"{nameValid} không được để trống.";

            return null;
        }

        /// <summary>Tối đa max ký tự.</summary>
        public static string? MaxLength(string nameValid, string? value, int max)
        {
            if (value != null && value.Length > max)
                return $"{nameValid} tối đa {max} ký tự.";

            return null;
        }

        /// <summary>Tối thiểu min ký tự.</summary>
        public static string? MinLength(string nameValid, string? value, int min)
        {
            if (value == null || value.Length < min)
                return $"{nameValid} tối thiểu {min} ký tự.";

            return null;
        }
    }
}