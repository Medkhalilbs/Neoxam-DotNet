namespace PI_Neoxam_GRH.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Enities;

    public partial class Context : DbContext
    {
        public Context(): base("name=Context")

        {

            //Disable initializer
            //Database.SetInitializer<SchoolDBContext>(null);

            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>()); //This is the default initializer

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());

        }

        public virtual DbSet<answer> answers { get; set; }
        public virtual DbSet<cv> cvs { get; set; }
        public virtual DbSet<departement> departements { get; set; }
        public virtual DbSet<domain> domains { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employeestatu> employeestatus { get; set; }
        public virtual DbSet<evalutaiontest> evalutaiontests { get; set; }
        public virtual DbSet<experience> experiences { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<hoby> hobies { get; set; }
        public virtual DbSet<language> languages { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<projet> projets { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<result> results { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<t_action> t_action { get; set; }
        public virtual DbSet<t_critere> t_critere { get; set; }
        public virtual DbSet<topic> topics { get; set; }
        public virtual DbSet<user_log> user_log { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<reclamation> reclamation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {






            modelBuilder.Entity<answer>()
              .Property(e => e.type_reponse)
              .IsUnicode(false);

            modelBuilder.Entity<cv>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<cv>()
                .Property(e => e.FileType)
                .IsUnicode(false);

            modelBuilder.Entity<cv>()
                .Property(e => e.OriginalFileType)
                .IsUnicode(false);

            modelBuilder.Entity<cv>()
                .Property(e => e.SenderIp)
                .IsUnicode(false);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.hobies)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv3_id);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.formations)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv2_id);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.experiences)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv1_id);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv5_id);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv6_id);

            modelBuilder.Entity<cv>()
                .HasMany(e => e.languages)
                .WithOptional(e => e.cv)
                .HasForeignKey(e => e.cv4_id);

            modelBuilder.Entity<departement>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<departement>()
                .HasMany(e => e.projets)
                .WithMany(e => e.departements)
                .Map(m => m.ToTable("projet_departement").MapLeftKey("departements_id").MapRightKey("projets_id"));

            modelBuilder.Entity<domain>()
                 .Property(e => e.name)
                 .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .HasMany(e => e.topic)
                .WithOptional(e => e.domain)
                .HasForeignKey(e => e.domain_id);


            modelBuilder.Entity<employee>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.position_held)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.Carrer_interview)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.Evalutaion)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.Job)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.employee_name)
                .IsUnicode(false);

            modelBuilder.Entity<employeestatu>()
                .Property(e => e.team_leader)
                .IsUnicode(false);

            modelBuilder.Entity<evalutaiontest>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<evalutaiontest>()
                .Property(e => e.Deadline)
                .IsUnicode(false);

            modelBuilder.Entity<evalutaiontest>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.addressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.addressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.zipCode)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<experience>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.Certification)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.addressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.addressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.zipCode)
                .IsUnicode(false);

            modelBuilder.Entity<hoby>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<hoby>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<hoby>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<hoby>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<language>()
                .Property(e => e.Lang)
                .IsUnicode(false);

            modelBuilder.Entity<language>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<language>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.destinataire)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.statusMessage)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.sujet)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.visibiliteMessage)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.Topic)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
               .Property(e => e.complexity)
               .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.enonce)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.indice)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.reponsejuste)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.answer)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.question_id);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<result>()
                .Property(e => e.result1)
                .IsUnicode(false);

            modelBuilder.Entity<result>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<t_action>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_critere>()
                .Property(e => e.DescrCritere)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
               .Property(e => e.image)
               .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.question)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.reclamation)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);


            modelBuilder.Entity<topic>()
                .HasMany(e => e.result)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.idtopic);

            modelBuilder.Entity<user_log>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<user_log>()
                .Property(e => e.ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<user_log>()
                .Property(e => e.pc_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_log>()
                .Property(e => e.session_id)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.house_number)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.zipCode)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DriverLience)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.SocialState)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Birthdate)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.cvs)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.Candidates_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.t_action)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.admin_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.t_critere)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.admin_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.user_log)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);
            modelBuilder.Entity<user>()
               .HasMany(e => e.result)
               .WithOptional(e => e.users)
               .HasForeignKey(e => e.idcandidate);
        }
    }
}
