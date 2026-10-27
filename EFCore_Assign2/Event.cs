namespace EFCore_Assign2;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string DetailedDescription { get; set; } = default!;
    public DateTime StartDate { get; set; } = default!;
    public DateTime? EndDate { get; set; }
    public int MaximumNumberOfAttendees { get; set; }
    // Foreign Key يربطه بـ Organizer
    public Organizer Organizer { get; set; } = default!;
    public int OrganizerId { get; set; }

    // علاقة self-referencing
    public Event? ParentEvent { get; set; }
    public int? ParentEventId { get; set; }

    //Session
    public ICollection<Event> Sessions { get; set; } = [];

    // many event Registering
    public ICollection<EventRegistering> Registrations { get; set; } = [];
}

public class Organizer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public OrganizerProfile OrganizerProfile { get; set; } = default!;

    //Events
    public ICollection<Event> Events { get; set; } = [];

}

public class OrganizerProfile
{
    public int Id { get; set; }
    public string? Bio { get; set; }
    public string? Website { get; set; }
    public string? UploadLogo { get; set; }

    // Foreign Key يربطه بـ Organizer
    public Organizer Organizer { get; set; } = default!;
    public int OrganizerId { get; set; }
}

public class Attendee
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string email { get; set; } = null!;
    public Address HomeAddress { get; set; } = null!;

    // Badge
    public Badge Badge { get; set; } = null!;

    // many
    // علاقة Many-to-Many مع الـ Events عبر جدول وسيط (Registration)
    public ICollection<EventRegistering> Registrations { get; set; } = [];
}
public class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}

public class Badge
{
    public int Id { get; set; }
    public string BadgeNumber { get; set; } = null!;
    public DateTime IssuedDate { get; set; }
    public BadgeTier BadgeTier { get; set; }

    // Badge has one attende
    public Attendee Attendee { get; set; } = null!;

    public int AttendeeId { get; set; }

}

public enum BadgeTier
{
    Standard = 1,
    VIP = 2
}

public class EventRegistering
{
    // Many Attendee 
    public Attendee Attendee { get; set; } = null!;

    public int AttendeeId { get; set; }

    // Many Event 
    public Event Event { get; set; } = null!;

    public int EventId { get; set; }

    public string? Note { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}