using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
    }
}