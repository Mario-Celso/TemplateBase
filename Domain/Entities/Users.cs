using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : IAggregateRoot
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Role { get; private set; }
        public string Cpf { get; private set; }
        public string UserName { get; private set; }
        public DateTime CreatedTimestamp { get; set; }

        public Users(string name, string password, int role, string email, string cpf, string userName)
        {
            Name = name;
            Password = password;
            Role = 0;
            Email = email;
            Cpf = cpf;
            UserName = userName;
            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "Nome não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Password, "Senha não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Email, "Email não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Cpf, "Cpf não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(UserName, "UserName não pode estar vazio!");
        }
    }
}
