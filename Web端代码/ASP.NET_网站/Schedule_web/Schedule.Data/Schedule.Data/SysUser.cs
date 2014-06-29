/*
insert license info here
*/
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Schedule.Data
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping template
	/// </summary>
	[DataContract]
    [Serializable]
	public  class SysUser
	{

		#region Private Members
		private bool isChanged;

		private string id; 
		private string username; 
		private string loginname; 
		private string password; 
		private string email; 
		private string phone; 
		private int status;
        private int userType;
		#endregion

		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public SysUser()
		{
			id = String.Empty; 
			username = String.Empty; 
			loginname = String.Empty; 
			password = String.Empty; 
			email = String.Empty; 
			phone = String.Empty; 
			status = 0;
            userType = 0;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Id
		{
			get { return id; }
			set
			{
				if(id != value)
				{
					id = value;
					isChanged = true;
					//OnPropertyChanged("Id");
				}
			}

		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string UserName
		{
			get { return username; }

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				if(username != value)
				{
					username = value;
					isChanged = true;
					//OnPropertyChanged("UserName");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string LoginName
		{
			get { return loginname; }

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for LoginName", value, value.ToString());
				
				if(loginname != value)
				{
					loginname = value;
					isChanged = true;
					//OnPropertyChanged("LoginName");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Password
		{
			get { return password; }

			set	
			{	
				if(  value != null &&  value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for Password", value, value.ToString());
				
				if(password != value)
				{
					password = value;
					isChanged = true;
					//OnPropertyChanged("Password");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Email
		{
			get { return email; }

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Email", value, value.ToString());
				
				if(email != value)
				{
					email = value;
					isChanged = true;
					//OnPropertyChanged("Email");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Phone
		{
			get { return phone; }

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Phone", value, value.ToString());
				
				if(phone != value)
				{
					phone = value;
					isChanged = true;
					//OnPropertyChanged("Phone");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual int Status
		{
			get { return status; }
			set
			{
				if(status != value)
				{
					status = value;
					isChanged = true;
					//OnPropertyChanged("Status");
				}
			}

		}
        [DataMember]
        public virtual int UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }
			
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsChanged
		{
			get { return isChanged; }
		}
				
		#endregion 

		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			SysUser castObj = (SysUser)obj; 
			return ( castObj != null ) &&
				( this.id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * id.GetHashCode();
			return hash; 
		}
		#endregion
			
    }
}
