/*
insert license info here
*/
using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Schedule.Data
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping template
	/// </summary>
	[DataContract]
	public  class Student
	{

		#region Private Members
		private bool m_isChanged;

		private string m_studentno; 
		private string m_name; 
		private string m_classno; 
		private string m_pwd; 
		private string m_phone; 
		private string m_email; 		
		#endregion

		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Student()
		{
			m_studentno = String.Empty; 
			m_name = String.Empty; 
			m_classno = String.Empty; 
			m_pwd = String.Empty; 
			m_phone = String.Empty; 
			m_email = String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		

		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string StudentNo
		{
			get { return m_studentno; }

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for StudentNo", value, "null");
				
				if(  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for StudentNo", value, value.ToString());
				
				if(m_studentno != value)
				{
					m_studentno = value;
					m_isChanged = true;
					//OnPropertyChanged("StudentNo");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Name
		{
			get { return m_name; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				
				if(m_name != value)
				{
					m_name = value;
					m_isChanged = true;
					//OnPropertyChanged("Name");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Classno
		{
			get { return m_classno; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Classno", value, value.ToString());
				
				if(m_classno != value)
				{
					m_classno = value;
					m_isChanged = true;
					//OnPropertyChanged("Classno");
					
				}
			}
		}
			
		/// <summary>
		/// 
		/// </summary>
		///
		[DataMember]
		public virtual string Pwd
		{
			get { return m_pwd; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Pwd", value, value.ToString());
				
				if(m_pwd != value)
				{
					m_pwd = value;
					m_isChanged = true;
					//OnPropertyChanged("Pwd");
					
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
			get { return m_phone; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Phone", value, value.ToString());
				
				if(m_phone != value)
				{
					m_phone = value;
					m_isChanged = true;
					//OnPropertyChanged("Phone");
					
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
			get { return m_email; }

			set	
			{	
				if(  value != null &&  value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Email", value, value.ToString());
				
				if(m_email != value)
				{
					m_email = value;
					m_isChanged = true;
					//OnPropertyChanged("Email");
					
				}
			}
		}
			
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsChanged
		{
			get { return m_isChanged; }
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
			Student castObj = (Student)obj; 
			return ( castObj != null ) &&
				( this.m_studentno == castObj.StudentNo );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * m_studentno.GetHashCode();
			return hash; 
		}
		#endregion
			}
}
