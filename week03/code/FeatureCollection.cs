public class FeaturesCollection
{
    public List<Feature> Features { get; set; }
}

public class Features
{
    public FeatureProperties Properties { get; set; }
}

public class FeaturesProperties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}
