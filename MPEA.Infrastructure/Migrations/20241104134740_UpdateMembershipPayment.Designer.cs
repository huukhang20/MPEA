﻿// <auto-generated />
using System;
using MPEA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MPEA.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241104134740_UpdateMembershipPayment")]
    partial class UpdateMembershipPayment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MPEA.Domain.Models.Category", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCateId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentCateId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Chat", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("MessageText")
                        .HasColumnType("text");

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Chat", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Exchange", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExchangeType")
                        .HasColumnType("text");

                    b.Property<Guid?>("OffererId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProviderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OffererId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Exchange", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeAgreement", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid?>("ExchangeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid?>("TermId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("TermId");

                    b.HasIndex("UserId");

                    b.ToTable("ExchangeAgreement", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeItem", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("ExchangeId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SparePartId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("SparePartId");

                    b.ToTable("ExchangeItem", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeTerm", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("ExchangeTerm", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Feedback", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Membership", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Membership", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Notification", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Payment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid?>("ExchangeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MembershipId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PayerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<Guid?>("PurchaseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId")
                        .IsUnique();

                    b.HasIndex("MembershipId");

                    b.HasIndex("PayerId");

                    b.HasIndex("PurchaseId")
                        .IsUnique();

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Post", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PartId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Purchase", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid?>("SellerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Purchase", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.PurchaseItem", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("PartId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("PurchaseId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseItem", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.RechargeHistory", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RechargeHistory", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Report", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid?>("PartId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ResolvedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("UserId");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.SparePart", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool?>("IsWarranty")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("WarrntyImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("SparePart", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("AvatarURL")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("MembershipId")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("MembershipId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.UserAddress", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Wallet", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int?>("Balance")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Wallet", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Wishlist", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<Guid?>("SparePartId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.HasIndex("UserId");

                    b.ToTable("Wishlist", (string)null);
                });

            modelBuilder.Entity("MPEA.Domain.Models.Category", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Category", "ParentCate")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCateId");

                    b.Navigation("ParentCate");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Chat", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "Receiver")
                        .WithMany("ChatReceiveds")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("MPEA.Domain.Models.User", "Sender")
                        .WithMany("ChatSents")
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Exchange", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "Offerer")
                        .WithMany("ExchangeOffers")
                        .HasForeignKey("OffererId");

                    b.HasOne("MPEA.Domain.Models.User", "Provider")
                        .WithMany("ExchangeProviders")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Offerer");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeAgreement", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Exchange", "Exchange")
                        .WithMany("Agreement")
                        .HasForeignKey("ExchangeId");

                    b.HasOne("MPEA.Domain.Models.ExchangeTerm", "ExchangeTerm")
                        .WithMany("Agreement")
                        .HasForeignKey("TermId");

                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("ExchangeAgreements")
                        .HasForeignKey("UserId");

                    b.Navigation("Exchange");

                    b.Navigation("ExchangeTerm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeItem", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Exchange", "Exchange")
                        .WithMany("Items")
                        .HasForeignKey("ExchangeId");

                    b.HasOne("MPEA.Domain.Models.SparePart", "SparePart")
                        .WithMany("ExchangeItems")
                        .HasForeignKey("SparePartId");

                    b.Navigation("Exchange");

                    b.Navigation("SparePart");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Feedback", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "Receiver")
                        .WithMany("FeedbackReceiveds")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("MPEA.Domain.Models.User", "Sender")
                        .WithMany("FeedbackSents")
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Notification", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Payment", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Exchange", "Exchange")
                        .WithOne("Payment")
                        .HasForeignKey("MPEA.Domain.Models.Payment", "ExchangeId");

                    b.HasOne("MPEA.Domain.Models.Membership", "Membership")
                        .WithMany("Payments")
                        .HasForeignKey("MembershipId");

                    b.HasOne("MPEA.Domain.Models.User", "Payer")
                        .WithMany("Payments")
                        .HasForeignKey("PayerId");

                    b.HasOne("MPEA.Domain.Models.Purchase", "Purchase")
                        .WithOne("Payment")
                        .HasForeignKey("MPEA.Domain.Models.Payment", "PurchaseId");

                    b.Navigation("Exchange");

                    b.Navigation("Membership");

                    b.Navigation("Payer");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Post", b =>
                {
                    b.HasOne("MPEA.Domain.Models.SparePart", "SparePart")
                        .WithMany("Posts")
                        .HasForeignKey("PartId");

                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("SparePart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Purchase", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "Buyer")
                        .WithMany("Bought")
                        .HasForeignKey("BuyerId");

                    b.HasOne("MPEA.Domain.Models.User", "Seller")
                        .WithMany("Sold")
                        .HasForeignKey("SellerId");

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("MPEA.Domain.Models.PurchaseItem", b =>
                {
                    b.HasOne("MPEA.Domain.Models.SparePart", "SparePart")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PartId");

                    b.HasOne("MPEA.Domain.Models.Purchase", "Purchase")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PurchaseId");

                    b.Navigation("Purchase");

                    b.Navigation("SparePart");
                });

            modelBuilder.Entity("MPEA.Domain.Models.RechargeHistory", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("RechargeHistories")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Report", b =>
                {
                    b.HasOne("MPEA.Domain.Models.SparePart", "SparePart")
                        .WithMany("Reports")
                        .HasForeignKey("PartId");

                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId");

                    b.Navigation("SparePart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.SparePart", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Category", "Category")
                        .WithMany("SpareParts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("SpareParts")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.User", b =>
                {
                    b.HasOne("MPEA.Domain.Models.Membership", "Membership")
                        .WithMany("Users")
                        .HasForeignKey("MembershipId");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("MPEA.Domain.Models.UserAddress", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Wallet", b =>
                {
                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("MPEA.Domain.Models.Wallet", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Wishlist", b =>
                {
                    b.HasOne("MPEA.Domain.Models.SparePart", "SparePart")
                        .WithMany("Wishlist")
                        .HasForeignKey("SparePartId");

                    b.HasOne("MPEA.Domain.Models.User", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("UserId");

                    b.Navigation("SparePart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Exchange", b =>
                {
                    b.Navigation("Agreement");

                    b.Navigation("Items");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("MPEA.Domain.Models.ExchangeTerm", b =>
                {
                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Membership", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MPEA.Domain.Models.Purchase", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("PurchaseItems");
                });

            modelBuilder.Entity("MPEA.Domain.Models.SparePart", b =>
                {
                    b.Navigation("ExchangeItems");

                    b.Navigation("Posts");

                    b.Navigation("PurchaseItems");

                    b.Navigation("Reports");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("MPEA.Domain.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Bought");

                    b.Navigation("ChatReceiveds");

                    b.Navigation("ChatSents");

                    b.Navigation("ExchangeAgreements");

                    b.Navigation("ExchangeOffers");

                    b.Navigation("ExchangeProviders");

                    b.Navigation("FeedbackReceiveds");

                    b.Navigation("FeedbackSents");

                    b.Navigation("Notifications");

                    b.Navigation("Payments");

                    b.Navigation("Posts");

                    b.Navigation("RechargeHistories");

                    b.Navigation("Reports");

                    b.Navigation("Sold");

                    b.Navigation("SpareParts");

                    b.Navigation("Wallet");

                    b.Navigation("Wishlists");
                });
#pragma warning restore 612, 618
        }
    }
}
