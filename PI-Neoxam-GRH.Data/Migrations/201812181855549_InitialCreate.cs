namespace PI_Neoxam_GRH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "answer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        juste = c.Boolean(nullable: false, storeType: "bit"),
                        type_reponse = c.String(maxLength: 255, unicode: false),
                        question_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("question", t => t.question_id)
                .Index(t => t.question_id);
            
            CreateTable(
                "question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        complexity = c.String(maxLength: 255, unicode: false),
                        enonce = c.String(maxLength: 255, unicode: false),
                        indice = c.String(maxLength: 255, unicode: false),
                        point = c.Double(nullable: false),
                        type = c.String(maxLength: 255, unicode: false),
                        topic_id = c.Int(),
                        reponsejuste = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("topic", t => t.topic_id)
                .Index(t => t.topic_id);
            
            CreateTable(
                "topic",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dureeTopic = c.Int(nullable: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        nombre_question = c.Int(nullable: false),
                        domain_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("domain", t => t.domain_id)
                .Index(t => t.domain_id);
            
            CreateTable(
                "domain",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, unicode: false),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "reclamation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date_creation = c.DateTime(precision: 0),
                        date_traitement = c.DateTime(precision: 0),
                        description = c.String(maxLength: 255, unicode: false),
                        objet = c.String(maxLength: 255, storeType: "nvarchar"),
                        etat = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        topic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("topic", t => t.topic_id)
                .Index(t => t.topic_id);
            
            CreateTable(
                "result",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(storeType: "date"),
                        result = c.String(maxLength: 255, unicode: false),
                        score = c.Double(nullable: false),
                        statut = c.String(maxLength: 255, unicode: false),
                        idcandidate = c.Int(),
                        idtopic = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("users", t => t.idcandidate)
                .ForeignKey("topic", t => t.idtopic)
                .Index(t => t.idcandidate)
                .Index(t => t.idtopic);
            
            CreateTable(
                "users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        role = c.String(nullable: false, maxLength: 31, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        login = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phone_number = c.String(maxLength: 255, unicode: false),
                        registration_date = c.DateTime(precision: 0),
                        status = c.String(maxLength: 255, unicode: false),
                        house_number = c.String(maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 255, unicode: false),
                        country = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 255, unicode: false),
                        zipCode = c.String(maxLength: 255, unicode: false),
                        markerColor = c.String(maxLength: 255, storeType: "nvarchar"),
                        cin = c.String(maxLength: 255, unicode: false),
                        first_name = c.String(maxLength: 255, unicode: false),
                        last_name = c.String(maxLength: 255, unicode: false),
                        Age = c.Int(),
                        lat = c.Double(),
                        lng = c.Double(),
                        Description = c.String(maxLength: 255, unicode: false),
                        DriverLience = c.String(maxLength: 255, unicode: false),
                        ProfilValide = c.Int(),
                        SocialState = c.String(maxLength: 255, unicode: false),
                        picture = c.String(maxLength: 255, unicode: false),
                        Birthdate = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "cv",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(maxLength: 255, unicode: false),
                        FileSize = c.Single(nullable: false),
                        FileType = c.String(maxLength: 255, unicode: false),
                        OriginalFileType = c.String(maxLength: 255, unicode: false),
                        SenderIp = c.String(maxLength: 255, unicode: false),
                        Candidates_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("users", t => t.Candidates_id)
                .Index(t => t.Candidates_id);
            
            CreateTable(
                "experience",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        addressLine1 = c.String(maxLength: 255, unicode: false),
                        addressLine2 = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 255, unicode: false),
                        country = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 255, unicode: false),
                        zipCode = c.String(maxLength: 255, unicode: false),
                        Company_Name = c.String(maxLength: 255, unicode: false),
                        Department = c.String(maxLength: 255, unicode: false),
                        Duration = c.Int(nullable: false),
                        End_Date = c.DateTime(precision: 0),
                        Role = c.String(maxLength: 255, unicode: false),
                        Sector = c.String(maxLength: 255, unicode: false),
                        Start_Date = c.DateTime(precision: 0),
                        Subject = c.String(maxLength: 255, unicode: false),
                        cv1_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv1_id)
                .Index(t => t.cv1_id);
            
            CreateTable(
                "formation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Certification = c.String(maxLength: 255, unicode: false),
                        End_Date = c.DateTime(precision: 0),
                        Start_Date = c.DateTime(precision: 0),
                        addressLine1 = c.String(maxLength: 255, unicode: false),
                        addressLine2 = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 255, unicode: false),
                        country = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 255, unicode: false),
                        zipCode = c.String(maxLength: 255, unicode: false),
                        duration = c.Int(nullable: false),
                        cv2_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv2_id)
                .Index(t => t.cv2_id);
            
            CreateTable(
                "hobies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Level = c.String(maxLength: 255, unicode: false),
                        Name = c.String(maxLength: 255, unicode: false),
                        Place = c.String(maxLength: 255, unicode: false),
                        Type = c.String(maxLength: 255, unicode: false),
                        cv3_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv3_id)
                .Index(t => t.cv3_id);
            
            CreateTable(
                "language",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Lang = c.String(maxLength: 255, unicode: false),
                        Level = c.String(maxLength: 255, unicode: false),
                        Type = c.String(maxLength: 255, unicode: false),
                        cv4_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv4_id)
                .Index(t => t.cv4_id);
            
            CreateTable(
                "project",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Topic = c.String(maxLength: 255, unicode: false),
                        dateProject = c.DateTime(precision: 0),
                        title = c.String(maxLength: 255, unicode: false),
                        cv5_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv5_id)
                .Index(t => t.cv5_id);
            
            CreateTable(
                "skills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Level = c.String(maxLength: 255, unicode: false),
                        Name = c.String(maxLength: 255, unicode: false),
                        Type = c.String(maxLength: 255, unicode: false),
                        cv6_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("cv", t => t.cv6_id)
                .Index(t => t.cv6_id);
            
            CreateTable(
                "messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        contenu = c.String(unicode: false),
                        dateEnvoie = c.DateTime(precision: 0),
                        dateLecture = c.DateTime(precision: 0),
                        destinataire = c.String(maxLength: 255, unicode: false),
                        statusMessage = c.String(maxLength: 255, unicode: false),
                        sujet = c.String(maxLength: 255, unicode: false),
                        visibiliteMessage = c.String(maxLength: 255, unicode: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "t_action",
                c => new
                    {
                        idAction = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        pourcentage = c.Double(nullable: false),
                        type = c.Int(),
                        admin_id = c.Int(),
                    })
                .PrimaryKey(t => t.idAction)
                .ForeignKey("users", t => t.admin_id)
                .Index(t => t.admin_id);
            
            CreateTable(
                "t_critere",
                c => new
                    {
                        idCritere = c.Int(nullable: false, identity: true),
                        DescrCritere = c.String(maxLength: 255, unicode: false),
                        Pourcentage = c.Int(nullable: false),
                        admin_id = c.Int(),
                    })
                .PrimaryKey(t => t.idCritere)
                .ForeignKey("users", t => t.admin_id)
                .Index(t => t.admin_id);
            
            CreateTable(
                "user_log",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country = c.String(maxLength: 255, unicode: false),
                        ip_address = c.String(maxLength: 255, unicode: false),
                        login_timestamp = c.DateTime(precision: 0),
                        logout_timestamp = c.DateTime(precision: 0),
                        pc_id = c.String(maxLength: 255, unicode: false),
                        session_id = c.String(maxLength: 255, unicode: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "departement",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "projet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(maxLength: 255, unicode: false),
                        status = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "employee",
                c => new
                    {
                        Cin = c.Int(nullable: false),
                        Recrutment_date = c.DateTime(storeType: "date"),
                        Salary = c.Int(nullable: false),
                        bonus_pts = c.Int(nullable: false),
                        childrens_nbr = c.Int(nullable: false),
                        mail = c.String(maxLength: 255, unicode: false),
                        nbr_holidays = c.Int(nullable: false),
                        nbr_late = c.Int(nullable: false),
                        position_held = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Cin);
            
            CreateTable(
                "employeestatus",
                c => new
                    {
                        Cin = c.Int(nullable: false),
                        Carrer_interview = c.String(maxLength: 255, unicode: false),
                        Department = c.String(maxLength: 255, unicode: false),
                        Evalutaion = c.String(maxLength: 255, unicode: false),
                        Job = c.String(maxLength: 255, unicode: false),
                        N1 = c.Int(nullable: false),
                        employee_name = c.String(maxLength: 255, unicode: false),
                        team_leader = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Cin);
            
            CreateTable(
                "evalutaiontest",
                c => new
                    {
                        Department = c.String(nullable: false, maxLength: 255, unicode: false),
                        Deadline = c.String(maxLength: 255, unicode: false),
                        Title = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Department);
            
            CreateTable(
                "projet_departement",
                c => new
                    {
                        departements_id = c.Int(nullable: false),
                        projets_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.departements_id, t.projets_id })
                .ForeignKey("departement", t => t.departements_id, cascadeDelete: true)
                .ForeignKey("projet", t => t.projets_id, cascadeDelete: true)
                .Index(t => t.departements_id)
                .Index(t => t.projets_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("projet_departement", "projets_id", "projet");
            DropForeignKey("projet_departement", "departements_id", "departement");
            DropForeignKey("result", "idtopic", "topic");
            DropForeignKey("user_log", "user_id", "users");
            DropForeignKey("t_critere", "admin_id", "users");
            DropForeignKey("t_action", "admin_id", "users");
            DropForeignKey("result", "idcandidate", "users");
            DropForeignKey("messages", "user_id", "users");
            DropForeignKey("cv", "Candidates_id", "users");
            DropForeignKey("skills", "cv6_id", "cv");
            DropForeignKey("project", "cv5_id", "cv");
            DropForeignKey("language", "cv4_id", "cv");
            DropForeignKey("hobies", "cv3_id", "cv");
            DropForeignKey("formation", "cv2_id", "cv");
            DropForeignKey("experience", "cv1_id", "cv");
            DropForeignKey("reclamation", "topic_id", "topic");
            DropForeignKey("question", "topic_id", "topic");
            DropForeignKey("topic", "domain_id", "domain");
            DropForeignKey("answer", "question_id", "question");
            DropIndex("projet_departement", new[] { "projets_id" });
            DropIndex("projet_departement", new[] { "departements_id" });
            DropIndex("user_log", new[] { "user_id" });
            DropIndex("t_critere", new[] { "admin_id" });
            DropIndex("t_action", new[] { "admin_id" });
            DropIndex("messages", new[] { "user_id" });
            DropIndex("skills", new[] { "cv6_id" });
            DropIndex("project", new[] { "cv5_id" });
            DropIndex("language", new[] { "cv4_id" });
            DropIndex("hobies", new[] { "cv3_id" });
            DropIndex("formation", new[] { "cv2_id" });
            DropIndex("experience", new[] { "cv1_id" });
            DropIndex("cv", new[] { "Candidates_id" });
            DropIndex("result", new[] { "idtopic" });
            DropIndex("result", new[] { "idcandidate" });
            DropIndex("reclamation", new[] { "topic_id" });
            DropIndex("topic", new[] { "domain_id" });
            DropIndex("question", new[] { "topic_id" });
            DropIndex("answer", new[] { "question_id" });
            DropTable("projet_departement");
            DropTable("evalutaiontest");
            DropTable("employeestatus");
            DropTable("employee");
            DropTable("projet");
            DropTable("departement");
            DropTable("user_log");
            DropTable("t_critere");
            DropTable("t_action");
            DropTable("messages");
            DropTable("skills");
            DropTable("project");
            DropTable("language");
            DropTable("hobies");
            DropTable("formation");
            DropTable("experience");
            DropTable("cv");
            DropTable("users");
            DropTable("result");
            DropTable("reclamation");
            DropTable("domain");
            DropTable("topic");
            DropTable("question");
            DropTable("answer");
        }
    }
}
