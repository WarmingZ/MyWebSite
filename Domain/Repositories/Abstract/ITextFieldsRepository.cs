using MyWebSite.Domain.Entities;
using System;
using System.Linq;


namespace MyWebSite.Domain.Repositories.Abstract
{
   public  interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields(); //Вибірка всіх текстових полів
        TextField GetTextFieldById(Guid id); //Вибір текстового поля по ід
        TextField GetTextFieldByCodeWord(string codeWord); //По кодовому слову
        void SaveTextField(TextField entity); //Зберегти зміни
        void DeleteTextField(Guid id); //Видалити текстове поле
    }
}
