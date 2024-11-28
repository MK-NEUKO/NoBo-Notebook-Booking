using System.Collections.Specialized;
using NoBo.Domain.Abstractions;
using NoBo.Domain.Shared;

namespace NoBo.Domain.Notebooks;

public sealed class Notebook : Entity
{
    public Notebook(
        Guid id,
        Name name,
        Description description,
        ArticleNumber articleNumber,
        Money price,
        TimeSpan availability,
        Display display,
        Processor processor,
        Graphic graphic,
        Ram ram,
        Storage storage,
        OperatingSystem operatingSystem,
        Battery battery,
        IoPorts ioPorts,
        Communication communication,
        Audio audio,
        Camera camera,
        Dimensions dimensions,
        List<Accessories> accessories) 
        : base(id)
    {
        Name = name;
        Description = description;
        ArticleNumber = articleNumber;
        Price = price;
        Availability = availability;
        Display = display;
        Processor = processor;
        Graphic = graphic;
        Ram = ram;
        Storage = storage;
        OperatingSystem = operatingSystem;
        Battery = battery;
        IoPorts = ioPorts;
        Communication = communication;
        Audio = audio;
        Camera = camera;
        Dimensions = dimensions;
        Accessories = accessories;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public ArticleNumber ArticleNumber { get; private set; }
    public Money Price { get; private set; }
    public TimeSpan Availability { get; private set; }
    public Display Display { get; private set; }
    public Processor Processor { get; private set; }
    public Graphic Graphic { get; private set; }
    public Ram Ram { get; private set; }
    public Storage Storage { get; private set; }
    public OperatingSystem OperatingSystem { get; private set; }
    public Battery Battery { get; private set; }
    public IoPorts IoPorts { get; private set; }
    public Communication Communication { get; private set; }
    public Audio Audio { get; private set; }
    public Camera Camera { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public List<Accessories> Accessories { get; private set; } = new();
}