using System.Collections.Specialized;
using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Notebooks;

public sealed class Notebook : Entity
{
    public Notebook(Guid id) 
        : base(id)
    {
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public ArticleNumber ArticleNumber { get; private set; }
    public Money Price { get; private set; }
    public TimeSpan Avalebility { get; private set; }
    public Display Display { get; private set; }
    public Processor Processor { get; private set; }
    public Graphic Graphic { get; private set; }
    public Ram Ram { get; private set; }
    public Storage Storage { get; private set; }
    public OperatingSystem OperatingSystem { get; private set; }
    public Battery Battery { get; private set; }
    public IOPorts IOPorts { get; private set; }
    public Communication Communication { get; private set; }
    public Audio Audio { get; private set; }
    public Camera Camera { get; private set; }
    public Dimensions Dimensions { get; private set; }
}