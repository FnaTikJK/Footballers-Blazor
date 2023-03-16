using System.ComponentModel.DataAnnotations;

namespace FootBallers.Models
{
    public class FootballerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateOnly Birthday { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
        public bool IsChangeable { get; set; }

        public static bool isValid(FootballerDto dto, out string error)
        {
            foreach (var propInfo in typeof(FootballerDto).GetProperties())
            {
                if (propInfo.GetValue(dto) == null || propInfo.GetValue(dto).ToString().Length == 0)
                {
                    error = $"Поле {propInfo.Name} не может быть пустым";
                    return false;
                }
            }

            error = "";
            return true;
        }
    }
}
