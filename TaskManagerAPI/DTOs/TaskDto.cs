using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}