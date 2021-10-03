using MyWebSite.Domain.Entities;
using System;
using System.Linq;


namespace MyWebSite.Domain.Repositories.Abstract
{
   public  interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields(); // Sample all text fields
        TextField GetTextFieldById(Guid id); // Select a text field by id
        TextField GetTextFieldByCodeWord(string codeWord); // According to the code word
        void SaveTextField(TextField entity); // Save changes
        void DeleteTextField(Guid id); // Delete text field
    }
}
