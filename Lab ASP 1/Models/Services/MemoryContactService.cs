namespace Lab_ASP_1.Models.Services;

public class MemoryContactService :IContactService
{
    private  Dictionary<int, ContactModel> _contacts = new()
    {
        { 1, new ContactModel {Id=1, FirstName = "Patryk", LastName = "Kowalski", Email = "patryk@o2.pl", BirthDate = new DateOnly(2003, 01, 13), PhoneNumber = "666 666 666",Category = Category.Family} },
        { 2, new ContactModel {Id=2, FirstName = "Michał", LastName = "Nowak", Email = "michal@o2.pl", BirthDate = new DateOnly(2003, 05, 12), PhoneNumber = "999 999 999",Category = Category.Friend } },
        { 3, new ContactModel {Id=3, FirstName = "Jakub", LastName = "Jankowski", Email = "jakub@o2.pl", BirthDate = new DateOnly(2003, 11, 02), PhoneNumber = "222 333 444",Category = Category.Business} }
    };


    private  int currentId = 3;
    public void Add(ContactModel model)
    {
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        
            _contacts[model.Id] = model;
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> GetOrganizations()
    {
        throw new NotImplementedException();
    }
}