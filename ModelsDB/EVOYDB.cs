namespace CompanyDbWebAPI.ModelsDB
{
    using System.Data.Entity;

    public partial class EVOYDB : DbContext
    {
        public EVOYDB()
            : base("name=EVOYDB")
        {
        }

        public virtual DbSet<BStage> BStages { get; set; }
        public virtual DbSet<Log_Update> Log_Updates { get; set; }


        public virtual DbSet<ContractConsultant> ContractConsultants { get; set; }
        public virtual DbSet<TBALocation> TBALocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractConsultant>()
                .HasKey(cc => cc.INITIALS)
                .HasOptional(cc => cc.LocationsAssigned);


            modelBuilder.Entity<TBALocation>()
                .HasKey(t => t.CODE)
                .HasOptional(t => t.Csl_Assigned)
                .WithMany(cc => cc.LocationsAssigned)
                .HasForeignKey(t => t.Csl_Assigned_INITIAL);

        }
    }
}
