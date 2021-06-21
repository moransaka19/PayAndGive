using System;

namespace Server.Models.Machine
{
    public class ContainerModel
    {
        public int Id { get; set; }

        public DateTime FixedLoadingTime { get; set; }

        public EatModel Eat { get; set; }

        public bool IsDeleted { get; set; }
    }
}