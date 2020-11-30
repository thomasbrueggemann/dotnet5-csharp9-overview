/*
  _____       _ _           ____        _         _____                           _   _           
 |_   _|     (_) |         / __ \      | |       |  __ \                         | | (_)          
   | |  _ __  _| |_ ______| |  | |_ __ | |_   _  | |__) | __ ___  _ __   ___ _ __| |_ _  ___  ___ 
   | | | '_ \| | __|______| |  | | '_ \| | | | | |  ___/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
  _| |_| | | | | |_       | |__| | | | | | |_| | | |   | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
 |_____|_| |_|_|\__|       \____/|_| |_|_|\__, | |_|   |_|  \___/| .__/ \___|_|   \__|_|\___||___/
                                           __/ |                 | |                              
                                          |___/                  |_|                              

- Init-only properties allow properties to only be set during object initiablization
- No setter needed
- Ensures less boilerplate to create immutable classes
- Helps with unit test setup as well (e.g. when setting up test-fixtures with AutoFixture)
    - Previously you'd have to register the constructor parameters as named parameters in AutoFixture
    - Now, using init-only properties, you can use AutoFixtures' .Build().With() pattern
*/

using AutoFixture;

var person = new PersonWithoutInit
{
    FirstName = "Tony",
    LastName = "Stark",
    Address = "10880 Malibu Point",
    City = "Malibu",
    FavoriteColor = "Red"
};

// immutable!
person.Address = "";

void SetupAutoFixtureWithoutInit()
{
    Fixture fixture = new();
    
    var brokenPersonFixture = fixture.Build<PersonWithoutInit>()
        .With(p => p.Address = "")
        .Create();
    
    fixture.Customizations.Add(new ParameterNameSpecimenBuilder<string>("firstName", "Emma"));

    var personFixture = fixture.Create<PersonWithoutInit>();
}

void SetupAutoFixtureWithInit()
{
    Fixture fixture = new();

    var personFixture = fixture.Build<PersonWithInit>()
        .With(p => p.FirstName == "Emma")
        .Create();
}

public class PersonWithoutInit
{
    public PersonWithoutInit() {}
    
    public PersonWithoutInit(string firstName, string lastName, string address, string city, string favoriteColor)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        FavoriteColor = favoriteColor;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string City { get; }
    public string FavoriteColor { get; }
}

public class PersonWithInit
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string FavoriteColor { get; init; }
}