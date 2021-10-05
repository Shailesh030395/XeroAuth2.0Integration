/* 
 * Accounting API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: api@xero.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Xero.NetStandard.OAuth2.Client.OpenAPIDateConverter;

namespace Xero.NetStandard.OAuth2.Model
{
    /// <summary>
    /// BankTransaction
    /// </summary>
    [DataContract]
    public partial class BankTransaction :  IEquatable<BankTransaction>, IValidatableObject
    {
        /// <summary>
        /// See Bank Transaction Types
        /// </summary>
        /// <value>See Bank Transaction Types</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum RECEIVE for value: RECEIVE
            /// </summary>
            [EnumMember(Value = "RECEIVE")]
            RECEIVE = 1,

            /// <summary>
            /// Enum RECEIVEOVERPAYMENT for value: RECEIVE-OVERPAYMENT
            /// </summary>
            [EnumMember(Value = "RECEIVE-OVERPAYMENT")]
            RECEIVEOVERPAYMENT = 2,

            /// <summary>
            /// Enum RECEIVEPREPAYMENT for value: RECEIVE-PREPAYMENT
            /// </summary>
            [EnumMember(Value = "RECEIVE-PREPAYMENT")]
            RECEIVEPREPAYMENT = 3,

            /// <summary>
            /// Enum SPEND for value: SPEND
            /// </summary>
            [EnumMember(Value = "SPEND")]
            SPEND = 4,

            /// <summary>
            /// Enum SPENDOVERPAYMENT for value: SPEND-OVERPAYMENT
            /// </summary>
            [EnumMember(Value = "SPEND-OVERPAYMENT")]
            SPENDOVERPAYMENT = 5,

            /// <summary>
            /// Enum SPENDPREPAYMENT for value: SPEND-PREPAYMENT
            /// </summary>
            [EnumMember(Value = "SPEND-PREPAYMENT")]
            SPENDPREPAYMENT = 6,

            /// <summary>
            /// Enum RECEIVETRANSFER for value: RECEIVE-TRANSFER
            /// </summary>
            [EnumMember(Value = "RECEIVE-TRANSFER")]
            RECEIVETRANSFER = 7,

            /// <summary>
            /// Enum SPENDTRANSFER for value: SPEND-TRANSFER
            /// </summary>
            [EnumMember(Value = "SPEND-TRANSFER")]
            SPENDTRANSFER = 8

        }

        /// <summary>
        /// See Bank Transaction Types
        /// </summary>
        /// <value>See Bank Transaction Types</value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        [DataMember(Name="CurrencyCode", EmitDefaultValue=false)]
        public CurrencyCode CurrencyCode { get; set; }
        /// <summary>
        /// See Bank Transaction Status Codes
        /// </summary>
        /// <value>See Bank Transaction Status Codes</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum AUTHORISED for value: AUTHORISED
            /// </summary>
            [EnumMember(Value = "AUTHORISED")]
            AUTHORISED = 1,

            /// <summary>
            /// Enum DELETED for value: DELETED
            /// </summary>
            [EnumMember(Value = "DELETED")]
            DELETED = 2,

            /// <summary>
            /// Enum VOIDED for value: VOIDED
            /// </summary>
            [EnumMember(Value = "VOIDED")]
            VOIDED = 3

        }

        /// <summary>
        /// See Bank Transaction Status Codes
        /// </summary>
        /// <value>See Bank Transaction Status Codes</value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Gets or Sets LineAmountTypes
        /// </summary>
        [DataMember(Name="LineAmountTypes", EmitDefaultValue=false)]
        public LineAmountTypes LineAmountTypes { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BankTransaction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public BankTransaction() { }
        
        /// <summary>
        /// Gets or Sets Contact
        /// </summary>
        [DataMember(Name="Contact", EmitDefaultValue=false)]
        public Contact Contact { get; set; }

        /// <summary>
        /// See LineItems
        /// </summary>
        /// <value>See LineItems</value>
        [DataMember(Name="LineItems", EmitDefaultValue=false)]
        public List<LineItem> LineItems { get; set; }

        /// <summary>
        /// Gets or Sets BankAccount
        /// </summary>
        [DataMember(Name="BankAccount", EmitDefaultValue=false)]
        public Account BankAccount { get; set; }

        /// <summary>
        /// Boolean to show if transaction is reconciled
        /// </summary>
        /// <value>Boolean to show if transaction is reconciled</value>
        [DataMember(Name="IsReconciled", EmitDefaultValue=false)]
        public bool? IsReconciled { get; set; }

        /// <summary>
        /// Date of transaction – YYYY-MM-DD
        /// </summary>
        /// <value>Date of transaction – YYYY-MM-DD</value>
        [DataMember(Name="Date", EmitDefaultValue=false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Reference for the transaction. Only supported for SPEND and RECEIVE transactions.
        /// </summary>
        /// <value>Reference for the transaction. Only supported for SPEND and RECEIVE transactions.</value>
        [DataMember(Name="Reference", EmitDefaultValue=false)]
        public string Reference { get; set; }

        /// <summary>
        /// Exchange rate to base currency when money is spent or received. e.g.0.7500 Only used for bank transactions in non base currency. If this isn’t specified for non base currency accounts then either the user-defined rate (preference) or the XE.com day rate will be used. Setting currency is only supported on overpayments.
        /// </summary>
        /// <value>Exchange rate to base currency when money is spent or received. e.g.0.7500 Only used for bank transactions in non base currency. If this isn’t specified for non base currency accounts then either the user-defined rate (preference) or the XE.com day rate will be used. Setting currency is only supported on overpayments.</value>
        [DataMember(Name="CurrencyRate", EmitDefaultValue=false)]
        public double? CurrencyRate { get; set; }

        /// <summary>
        /// URL link to a source document – shown as “Go to App Name”
        /// </summary>
        /// <value>URL link to a source document – shown as “Go to App Name”</value>
        [DataMember(Name="Url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Total of bank transaction excluding taxes
        /// </summary>
        /// <value>Total of bank transaction excluding taxes</value>
        [DataMember(Name="SubTotal", EmitDefaultValue=false)]
        public double? SubTotal { get; set; }

        /// <summary>
        /// Total tax on bank transaction
        /// </summary>
        /// <value>Total tax on bank transaction</value>
        [DataMember(Name="TotalTax", EmitDefaultValue=false)]
        public double? TotalTax { get; set; }

        /// <summary>
        /// Total of bank transaction tax inclusive
        /// </summary>
        /// <value>Total of bank transaction tax inclusive</value>
        [DataMember(Name="Total", EmitDefaultValue=false)]
        public double? Total { get; set; }

        /// <summary>
        /// Xero generated unique identifier for bank transaction
        /// </summary>
        /// <value>Xero generated unique identifier for bank transaction</value>
        [DataMember(Name="BankTransactionID", EmitDefaultValue=false)]
        public Guid BankTransactionID { get; set; }

        /// <summary>
        /// Xero generated unique identifier for a Prepayment. This will be returned on BankTransactions with a Type of SPEND-PREPAYMENT or RECEIVE-PREPAYMENT
        /// </summary>
        /// <value>Xero generated unique identifier for a Prepayment. This will be returned on BankTransactions with a Type of SPEND-PREPAYMENT or RECEIVE-PREPAYMENT</value>
        [DataMember(Name="PrepaymentID", EmitDefaultValue=false)]
        public Guid PrepaymentID { get; private set; }

        /// <summary>
        /// Xero generated unique identifier for an Overpayment. This will be returned on BankTransactions with a Type of SPEND-OVERPAYMENT or RECEIVE-OVERPAYMENT
        /// </summary>
        /// <value>Xero generated unique identifier for an Overpayment. This will be returned on BankTransactions with a Type of SPEND-OVERPAYMENT or RECEIVE-OVERPAYMENT</value>
        [DataMember(Name="OverpaymentID", EmitDefaultValue=false)]
        public Guid OverpaymentID { get; private set; }

        /// <summary>
        /// Last modified date UTC format
        /// </summary>
        /// <value>Last modified date UTC format</value>
        [DataMember(Name="UpdatedDateUTC", EmitDefaultValue=false)]
        public DateTime? UpdatedDateUTC { get; private set; }

        /// <summary>
        /// Boolean to indicate if a bank transaction has an attachment
        /// </summary>
        /// <value>Boolean to indicate if a bank transaction has an attachment</value>
        [DataMember(Name="HasAttachments", EmitDefaultValue=false)]
        public bool? HasAttachments { get; private set; }

        /// <summary>
        /// A string to indicate if a invoice status
        /// </summary>
        /// <value>A string to indicate if a invoice status</value>
        [DataMember(Name="StatusAttributeString", EmitDefaultValue=false)]
        public string StatusAttributeString { get; set; }

        /// <summary>
        /// Displays array of validation error messages from the API
        /// </summary>
        /// <value>Displays array of validation error messages from the API</value>
        [DataMember(Name="ValidationErrors", EmitDefaultValue=false)]
        public List<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BankTransaction {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  LineItems: ").Append(LineItems).Append("\n");
            sb.Append("  BankAccount: ").Append(BankAccount).Append("\n");
            sb.Append("  IsReconciled: ").Append(IsReconciled).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  CurrencyRate: ").Append(CurrencyRate).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  LineAmountTypes: ").Append(LineAmountTypes).Append("\n");
            sb.Append("  SubTotal: ").Append(SubTotal).Append("\n");
            sb.Append("  TotalTax: ").Append(TotalTax).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  BankTransactionID: ").Append(BankTransactionID).Append("\n");
            sb.Append("  PrepaymentID: ").Append(PrepaymentID).Append("\n");
            sb.Append("  OverpaymentID: ").Append(OverpaymentID).Append("\n");
            sb.Append("  UpdatedDateUTC: ").Append(UpdatedDateUTC).Append("\n");
            sb.Append("  HasAttachments: ").Append(HasAttachments).Append("\n");
            sb.Append("  StatusAttributeString: ").Append(StatusAttributeString).Append("\n");
            sb.Append("  ValidationErrors: ").Append(ValidationErrors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BankTransaction);
        }

        /// <summary>
        /// Returns true if BankTransaction instances are equal
        /// </summary>
        /// <param name="input">Instance of BankTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BankTransaction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Contact == input.Contact ||
                    (this.Contact != null &&
                    this.Contact.Equals(input.Contact))
                ) && 
                (
                    this.LineItems == input.LineItems ||
                    this.LineItems != null &&
                    input.LineItems != null &&
                    this.LineItems.SequenceEqual(input.LineItems)
                ) && 
                (
                    this.BankAccount == input.BankAccount ||
                    (this.BankAccount != null &&
                    this.BankAccount.Equals(input.BankAccount))
                ) && 
                (
                    this.IsReconciled == input.IsReconciled ||
                    this.IsReconciled.Equals(input.IsReconciled)
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Reference == input.Reference ||
                    (this.Reference != null &&
                    this.Reference.Equals(input.Reference))
                ) && 
                (
                    this.CurrencyCode == input.CurrencyCode ||
                    this.CurrencyCode.Equals(input.CurrencyCode)
                ) && 
                (
                    this.CurrencyRate == input.CurrencyRate ||
                    this.CurrencyRate.Equals(input.CurrencyRate)
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.LineAmountTypes == input.LineAmountTypes ||
                    this.LineAmountTypes.Equals(input.LineAmountTypes)
                ) && 
                (
                    this.SubTotal == input.SubTotal ||
                    this.SubTotal.Equals(input.SubTotal)
                ) && 
                (
                    this.TotalTax == input.TotalTax ||
                    this.TotalTax.Equals(input.TotalTax)
                ) && 
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
                ) && 
                (
                    this.BankTransactionID == input.BankTransactionID ||
                    (this.BankTransactionID != null &&
                    this.BankTransactionID.Equals(input.BankTransactionID))
                ) && 
                (
                    this.PrepaymentID == input.PrepaymentID ||
                    (this.PrepaymentID != null &&
                    this.PrepaymentID.Equals(input.PrepaymentID))
                ) && 
                (
                    this.OverpaymentID == input.OverpaymentID ||
                    (this.OverpaymentID != null &&
                    this.OverpaymentID.Equals(input.OverpaymentID))
                ) && 
                (
                    this.UpdatedDateUTC == input.UpdatedDateUTC ||
                    (this.UpdatedDateUTC != null &&
                    this.UpdatedDateUTC.Equals(input.UpdatedDateUTC))
                ) && 
                (
                    this.HasAttachments == input.HasAttachments ||
                    this.HasAttachments.Equals(input.HasAttachments)
                ) && 
                (
                    this.StatusAttributeString == input.StatusAttributeString ||
                    (this.StatusAttributeString != null &&
                    this.StatusAttributeString.Equals(input.StatusAttributeString))
                ) && 
                (
                    this.ValidationErrors == input.ValidationErrors ||
                    this.ValidationErrors != null &&
                    input.ValidationErrors != null &&
                    this.ValidationErrors.SequenceEqual(input.ValidationErrors)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Contact != null)
                    hashCode = hashCode * 59 + this.Contact.GetHashCode();
                if (this.LineItems != null)
                    hashCode = hashCode * 59 + this.LineItems.GetHashCode();
                if (this.BankAccount != null)
                    hashCode = hashCode * 59 + this.BankAccount.GetHashCode();
                hashCode = hashCode * 59 + this.IsReconciled.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Reference != null)
                    hashCode = hashCode * 59 + this.Reference.GetHashCode();
                hashCode = hashCode * 59 + this.CurrencyCode.GetHashCode();
                hashCode = hashCode * 59 + this.CurrencyRate.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                hashCode = hashCode * 59 + this.LineAmountTypes.GetHashCode();
                hashCode = hashCode * 59 + this.SubTotal.GetHashCode();
                hashCode = hashCode * 59 + this.TotalTax.GetHashCode();
                hashCode = hashCode * 59 + this.Total.GetHashCode();
                if (this.BankTransactionID != null)
                    hashCode = hashCode * 59 + this.BankTransactionID.GetHashCode();
                if (this.PrepaymentID != null)
                    hashCode = hashCode * 59 + this.PrepaymentID.GetHashCode();
                if (this.OverpaymentID != null)
                    hashCode = hashCode * 59 + this.OverpaymentID.GetHashCode();
                if (this.UpdatedDateUTC != null)
                    hashCode = hashCode * 59 + this.UpdatedDateUTC.GetHashCode();
                hashCode = hashCode * 59 + this.HasAttachments.GetHashCode();
                if (this.StatusAttributeString != null)
                    hashCode = hashCode * 59 + this.StatusAttributeString.GetHashCode();
                if (this.ValidationErrors != null)
                    hashCode = hashCode * 59 + this.ValidationErrors.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
