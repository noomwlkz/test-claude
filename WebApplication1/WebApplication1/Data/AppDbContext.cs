using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetMaster> AssetMasters { get; set; }

    public virtual DbSet<AssetMasterBk20260126> AssetMasterBk20260126s { get; set; }

    public virtual DbSet<AuthKey> AuthKeys { get; set; }

    public virtual DbSet<BidAuction> BidAuctions { get; set; }

    public virtual DbSet<BidHistory> BidHistories { get; set; }

    public virtual DbSet<Committee> Committees { get; set; }

    public virtual DbSet<ControlDate> ControlDates { get; set; }

    public virtual DbSet<ControlDateBk20260126> ControlDateBk20260126s { get; set; }

    public virtual DbSet<CustomerList> CustomerLists { get; set; }

    public virtual DbSet<ParameterMapping> ParameterMappings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<ReceiptRunning> ReceiptRunnings { get; set; }

    public virtual DbSet<RegisterList> RegisterLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetMaster>(entity =>
        {
            entity.HasKey(e => e.AssetId);

            entity.ToTable("asset_master", "auction");

            entity.Property(e => e.AssetId)
                .HasMaxLength(30)
                .HasColumnName("asset_id");
            entity.Property(e => e.AddressFulltext)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("address_fulltext");
            entity.Property(e => e.AssetName)
                .HasMaxLength(200)
                .HasColumnName("asset_name");
            entity.Property(e => e.AssetNo)
                .HasMaxLength(10)
                .HasColumnName("asset_no");
            entity.Property(e => e.AssetNum)
                .HasMaxLength(100)
                .HasColumnName("asset_num");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("asset_type");
            entity.Property(e => e.BeforeStatusFlg)
                .HasMaxLength(5)
                .HasColumnName("before_status_flg");
            entity.Property(e => e.Created)
                .HasPrecision(0)
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DeedNo)
                .HasMaxLength(30)
                .HasColumnName("deed_no");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(10)
                .HasColumnName("district_code");
            entity.Property(e => e.Floor)
                .HasMaxLength(10)
                .HasColumnName("floor");
            entity.Property(e => e.FloorNo)
                .HasMaxLength(10)
                .HasColumnName("floor_no");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(50)
                .HasColumnName("house_no");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("img_url");
            entity.Property(e => e.LastUpd)
                .HasPrecision(0)
                .HasColumnName("last_upd");
            entity.Property(e => e.LastUpdBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_upd_by");
            entity.Property(e => e.Moo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("moo");
            entity.Property(e => e.Price)
                .HasMaxLength(30)
                .HasColumnName("price");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .HasColumnName("province");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(10)
                .HasColumnName("province_code");
            entity.Property(e => e.Road)
                .HasMaxLength(50)
                .HasColumnName("road");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.Soi)
                .HasMaxLength(50)
                .HasColumnName("soi");
            entity.Property(e => e.StatusFlg)
                .HasMaxLength(5)
                .HasColumnName("status_flg");
            entity.Property(e => e.Subdistrict)
                .HasMaxLength(100)
                .HasColumnName("subdistrict");
            entity.Property(e => e.SubdistrictCode)
                .HasMaxLength(10)
                .HasColumnName("subdistrict_code");
            entity.Property(e => e.Tel)
                .HasMaxLength(30)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<AssetMasterBk20260126>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("asset_master_bk_20260126", "auction");

            entity.Property(e => e.AssetId)
                .HasMaxLength(30)
                .HasColumnName("asset_id");
            entity.Property(e => e.AssetName)
                .HasMaxLength(200)
                .HasColumnName("asset_name");
            entity.Property(e => e.AssetNo)
                .HasMaxLength(10)
                .HasColumnName("asset_no");
            entity.Property(e => e.AssetNum)
                .HasMaxLength(20)
                .HasColumnName("asset_num");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("asset_type");
            entity.Property(e => e.DeedNo)
                .HasMaxLength(30)
                .HasColumnName("deed_no");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.Floor)
                .HasMaxLength(10)
                .HasColumnName("floor");
            entity.Property(e => e.FloorNo)
                .HasMaxLength(10)
                .HasColumnName("floor_no");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(10)
                .HasColumnName("house_no");
            entity.Property(e => e.Price)
                .HasMaxLength(30)
                .HasColumnName("price");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .HasColumnName("province");
            entity.Property(e => e.Road)
                .HasMaxLength(50)
                .HasColumnName("road");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.Soi)
                .HasMaxLength(50)
                .HasColumnName("soi");
            entity.Property(e => e.StatusFlg)
                .HasMaxLength(5)
                .HasColumnName("status_flg");
            entity.Property(e => e.Subdistrict)
                .HasMaxLength(100)
                .HasColumnName("subdistrict");
            entity.Property(e => e.Tel)
                .HasMaxLength(30)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<AuthKey>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("auth_key", "auction");

            entity.Property(e => e.AuthKey1)
                .HasMaxLength(100)
                .HasColumnName("auth_key");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
        });

        modelBuilder.Entity<BidAuction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bid_auction_pk");

            entity.ToTable("bid_auction", "auction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveStatusPrm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("approve_status_prm");
            entity.Property(e => e.AssetId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asset_id");
            entity.Property(e => e.BidPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bid_price");
            entity.Property(e => e.BidStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("available, bidding, completed")
                .HasColumnName("bid_status");
            entity.Property(e => e.BidWinner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("cust_key")
                .HasColumnName("bid_winner");
            entity.Property(e => e.CancelFlgPrm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cancel_flg_prm");
            entity.Property(e => e.Committee1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("committee_1");
            entity.Property(e => e.Committee2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("committee_2");
            entity.Property(e => e.ContractCreateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contract_create_by");
            entity.Property(e => e.ContractCreateDt)
                .HasComment("วันที่นัดทำสัญญา")
                .HasColumnType("datetime")
                .HasColumnName("contract_create_dt");
            entity.Property(e => e.ContractDt)
                .HasColumnType("datetime")
                .HasColumnName("contract_dt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_dt");
            entity.Property(e => e.EditPriceFlgPrm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("edit_price_flg_prm");
            entity.Property(e => e.IsPayment).HasColumnName("is_payment");
            entity.Property(e => e.PromotionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("promotion_id");
            entity.Property(e => e.Reason)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.StartPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("start_price");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDt)
                .HasPrecision(0)
                .HasColumnName("update_dt");
        });

        modelBuilder.Entity<BidHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bid_history_pk");

            entity.ToTable("bid_history", "auction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionLv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("plus, manual")
                .HasColumnName("action_lv");
            entity.Property(e => e.AssetId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asset_id");
            entity.Property(e => e.AuctionId).HasColumnName("auction_id");
            entity.Property(e => e.BidPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bid_price");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_dt");
            entity.Property(e => e.PromotionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("promotion_id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDt)
                .HasPrecision(0)
                .HasColumnName("update_dt");
        });

        modelBuilder.Entity<Committee>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("committee", "auction");

            entity.Property(e => e.RowId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("row_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emp_code");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.StatusValue)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("status_value");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("update_dt");
        });

        modelBuilder.Entity<ControlDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("control_date", "auction");

            entity.Property(e => e.AuctionEnd)
                .HasColumnType("datetime")
                .HasColumnName("auctionEnd");
            entity.Property(e => e.AuctionName)
                .HasMaxLength(500)
                .HasColumnName("auctionName");
            entity.Property(e => e.AuctionStart)
                .HasColumnType("datetime")
                .HasColumnName("auctionStart");
            entity.Property(e => e.BackgroundImgUrl).HasColumnName("background_img_url");
            entity.Property(e => e.CongratsImgUrl).HasColumnName("congrats_img_url");
            entity.Property(e => e.ContractEndDt)
                .HasColumnType("datetime")
                .HasColumnName("contract_end_dt");
            entity.Property(e => e.ContractStartDt)
                .HasColumnType("datetime")
                .HasColumnName("contract_start_dt");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.ImgId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("img_id");
            entity.Property(e => e.LastUpd)
                .HasColumnType("datetime")
                .HasColumnName("last_upd");
            entity.Property(e => e.LastUpdBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("last_upd_by");
            entity.Property(e => e.PromotionId)
                .HasMaxLength(50)
                .HasColumnName("promotion_id");
            entity.Property(e => e.UrlConsent)
                .HasMaxLength(500)
                .HasColumnName("url_consent");
        });

        modelBuilder.Entity<ControlDateBk20260126>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("control_date_bk_20260126", "auction");

            entity.Property(e => e.AuctionEnd)
                .HasColumnType("datetime")
                .HasColumnName("auctionEnd");
            entity.Property(e => e.AuctionName)
                .HasMaxLength(500)
                .HasColumnName("auctionName");
            entity.Property(e => e.AuctionStart)
                .HasColumnType("datetime")
                .HasColumnName("auctionStart");
            entity.Property(e => e.PromotionId)
                .HasMaxLength(50)
                .HasColumnName("promotion_id");
            entity.Property(e => e.Tmp1)
                .HasMaxLength(500)
                .HasColumnName("tmp1");
        });

        modelBuilder.Entity<CustomerList>(entity =>
        {
            entity.HasKey(e => e.CustKey);

            entity.ToTable("customer_list", "auction");

            entity.Property(e => e.CustKey)
                .HasMaxLength(100)
                .HasColumnName("cust_key");
            entity.Property(e => e.Address)
                .HasMaxLength(800)
                .HasColumnName("address");
            entity.Property(e => e.AuthFlag)
                .HasMaxLength(5)
                .HasComment("T - ThaID, \r\nM - Manual, \r\nS - Scan ID Card")
                .HasColumnName("auth_flag");
            entity.Property(e => e.AuthType)
                .HasMaxLength(10)
                .HasComment("IND - ประมูลเอง (Individual), \r\nAGT - ผู้รับมอบอำนาจ (Agent), \r\nCOM - ประมูลในนามบริษัท (Company)")
                .HasColumnName("auth_type");
            entity.Property(e => e.AuthorizedPerson)
                .HasMaxLength(500)
                .HasColumnName("authorized_person");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.IsVerify).HasColumnName("is_verify");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Ssn)
                .HasMaxLength(20)
                .HasColumnName("ssn");
            entity.Property(e => e.Surname)
                .HasMaxLength(500)
                .HasColumnName("surname");
            entity.Property(e => e.TelNum)
                .HasMaxLength(20)
                .HasColumnName("tel_num");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<ParameterMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("parameter_mapping", "auction");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasPrecision(0)
                .HasColumnName("created_dt");
            entity.Property(e => e.TypeCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type_code");
            entity.Property(e => e.TypeDesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_desc");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDt)
                .HasPrecision(0)
                .HasColumnName("update_dt");
            entity.Property(e => e.ValueCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value_code");
            entity.Property(e => e.ValueDesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("value_desc");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("payments", "auction");

            entity.Property(e => e.RowId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("row_id");
            entity.Property(e => e.AccntInfoId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("accnt_info_id");
            entity.Property(e => e.Amount)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AmountTxt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("amount_txt");
            entity.Property(e => e.BankAndBranch)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("bank_and_branch");
            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("branch_name");
            entity.Property(e => e.CancelDt)
                .HasColumnType("datetime")
                .HasColumnName("cancel_dt");
            entity.Property(e => e.Canceller)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("canceller");
            entity.Property(e => e.ChequeDt)
                .HasColumnType("datetime")
                .HasColumnName("cheque_dt");
            entity.Property(e => e.ChequeNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cheque_no");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.LastUpd)
                .HasColumnType("datetime")
                .HasColumnName("last_upd");
            entity.Property(e => e.LastUpdBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("last_upd_by");
            entity.Property(e => e.MethodCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("method_code");
            entity.Property(e => e.PaymentDt)
                .HasColumnType("datetime")
                .HasColumnName("payment_dt");
            entity.Property(e => e.ReceiptNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receipt_no");
            entity.Property(e => e.StatusLv)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("status_lv");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PK_payment_detail");

            entity.ToTable("payment_details", "auction");

            entity.Property(e => e.RowId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("row_id");
            entity.Property(e => e.Amount)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AssetId)
                .HasMaxLength(30)
                .HasColumnName("asset_id");
            entity.Property(e => e.AssetNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("asset_no");
            entity.Property(e => e.AssetNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("asset_num");
            entity.Property(e => e.BidPrice)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("bid_price");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("item_code");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.LastUpd)
                .HasColumnType("datetime")
                .HasColumnName("last_upd");
            entity.Property(e => e.LastUpdBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("last_upd_by");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("payment_id");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
            entity.Property(e => e.StatusLv)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("status_lv");
        });

        modelBuilder.Entity<ReceiptRunning>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("receipt_running", "auction");

            entity.Property(e => e.RowId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("row_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DivCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("div_code");
            entity.Property(e => e.LastUpd)
                .HasColumnType("datetime")
                .HasColumnName("last_upd");
            entity.Property(e => e.LastUpdBy)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("last_upd_by");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("reference_type");
            entity.Property(e => e.Runno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("runno");
            entity.Property(e => e.StatusLv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status_lv");
            entity.Property(e => e.YearVal).HasColumnName("year_val");
        });

        modelBuilder.Entity<RegisterList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("register_list", "auction");

            entity.Property(e => e.AssetId)
                .HasMaxLength(30)
                .HasColumnName("asset_id");
            entity.Property(e => e.AssetName)
                .HasMaxLength(200)
                .HasColumnName("asset_name");
            entity.Property(e => e.AssetNo)
                .HasMaxLength(10)
                .HasColumnName("asset_no");
            entity.Property(e => e.AssetNum)
                .HasMaxLength(20)
                .HasColumnName("asset_num");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("asset_type");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CustKey)
                .HasMaxLength(100)
                .HasColumnName("cust_key");
            entity.Property(e => e.DeedNo)
                .HasMaxLength(30)
                .HasColumnName("deed_no");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("district");
            entity.Property(e => e.Floor)
                .HasMaxLength(10)
                .HasColumnName("floor");
            entity.Property(e => e.FloorNo)
                .HasMaxLength(10)
                .HasColumnName("floor_no");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(100)
                .HasColumnName("house_no");
            entity.Property(e => e.Moo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("moo");
            entity.Property(e => e.PresenceFlg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("presence_flg");
            entity.Property(e => e.Price)
                .HasMaxLength(30)
                .HasColumnName("price");
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .HasColumnName("province");
            entity.Property(e => e.Road)
                .HasMaxLength(50)
                .HasColumnName("road");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.Soi)
                .HasMaxLength(50)
                .HasColumnName("soi");
            entity.Property(e => e.Subdistrict)
                .HasMaxLength(100)
                .HasColumnName("subdistrict");
            entity.Property(e => e.Tel)
                .HasMaxLength(30)
                .HasColumnName("tel");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasPrecision(0)
                .HasColumnName("update_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
