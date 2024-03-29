﻿using System.ComponentModel;

namespace FootBallers.Entities
{
    public class Footballer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }
        public Team Team { get; set; }
        public Country Country { get; set; }
    }
}
