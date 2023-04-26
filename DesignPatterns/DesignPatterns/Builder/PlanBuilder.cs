using System.Collections.Generic;

namespace DesignPatterns.Builder
{
    public class PlanDirector
    {
        public void Debug()
        {
            BuildBasicPlan();
            BuildCustomPlan();
        }
        public void BuildBasicPlan()
        {
            IPlanBuilder builder = new BasicPlanBuilder();
            builder.AddBandWidth();
            builder.AddDatabase();
            builder.AddDiskSpace();
            builder.AddSSLFeature();
            plan _plan = builder.Getplan();
        }
        public void BuildCustomPlan()
        {
            IPlanBuilder builder = new CustomPlanBuilder();
            builder.AddBandWidth();
            builder.AddDatabase();
            builder.AddDiskSpace();
            builder.AddSSLFeature();
            plan _plan = builder.Getplan();
        }
    }
    public class BasicPlanBuilder : IPlanBuilder
    {
        plan _plan = new plan();
        public BasicPlanBuilder()
        {
            reset();
        }
        private void reset()
        {
            _plan = new plan { Name = "Basic", Price = 10 };
        }
        public void AddBandWidth()
        {
            _plan.AddFeature(new Feature() { Title = "Bandwidth", Value = "10 GB" });
        }

        public void AddDatabase()
        {
            _plan.AddFeature(new Feature() { Title = "Database Size", Value = "5 GB" });
        }

        public void AddDiskSpace()
        {
            _plan.AddFeature(new Feature() { Title = "Disk Space", Value = "1 GB" });
        }

        public void AddSSLFeature()
        {
            _plan.AddFeature(new Feature() { Title = "SSL", Value = "Not Free" });
        }

        public plan Getplan() => _plan;
    }
    public class CustomPlanBuilder : IPlanBuilder
    {
        plan _plan = new plan();
        public CustomPlanBuilder()
        {
            _plan = new plan { Name = "Basic", Price = 10 };
        }
        public void AddBandWidth()
        {
            _plan.AddFeature(new Feature() { Title = "Bandwidth", Value = "Unlimited" });
        }
        public void AddDatabase()
        {
            _plan.AddFeature(new Feature() { Title = "Database Size", Value = "500 GB" });
        }
        public void AddDiskSpace()
        {
            _plan.AddFeature(new Feature() { Title = "Disk Space", Value = "100 GB" });
        }
        public void AddSSLFeature()
        {
            _plan.AddFeature(new Feature() { Title = "SSL", Value = "Free" });
        }
        public plan Getplan() => _plan;
    }
    public interface IPlanBuilder
    {
        void AddDiskSpace();
        void AddDatabase();
        void AddBandWidth();
        void AddSSLFeature();
        plan Getplan();
    }

    public class plan
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Feature> Features = new List<Feature>();
        public void AddFeature(Feature feature)
        {
            Features.Add(feature);
        }
    }
    public class Feature
    {
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
