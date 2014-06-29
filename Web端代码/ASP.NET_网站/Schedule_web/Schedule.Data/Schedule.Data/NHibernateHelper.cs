using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;
using System.Data;



namespace Schedule.Data
{
    public class NHibernateHelper
    {
        public NHibernateHelper()
        {
            AutoCloseSession = true;
        }
        public NHibernateHelper(bool isAutoCloseSession)
        {
            AutoCloseSession = isAutoCloseSession;
        }

        private static NHibernate.ISessionFactory sessionFactory;
        private static System.Collections.ArrayList activeSessionList;
        
        private static NHibernate.ISession sessionInstance = null;

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public static string DBConnectionString;
        public static void init()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.getSession();
            helper.CloseSession(session);
        }

        private bool m_autoCloseSession;

        protected string _lastError;
        public string LastError
        {
            get { return _lastError; }
        }
        protected Exception lastException;
        public Exception LastException
        {
            get { return lastException; }
        }
        /// <summary>
        /// �Ƿ��Զ��رջỰ���ԣ�Ĭ�ϲ��ر�
        /// </summary>
        public bool AutoCloseSession
        {
            get { return m_autoCloseSession; }
            set { m_autoCloseSession = value; }
        }
        /**
         * �ر������Ѵ򿪵ĻỰ
         * */
        public static void Destory()
        {
            if (activeSessionList != null)
            {
                for (int i = 0; i < activeSessionList.Count; i++)
                {
                    ISession s = (ISession)activeSessionList[i];
                    if (s == null)
                    {
                        if (s.IsOpen != false)
                        {
                            s.Close();
                        }
                    }
                }
                activeSessionList.Clear();
                activeSessionList = null;
            }
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
        /**
         * <summary>
         * ��ȡ��ǰ�Ự��
         * </summary>
         * 
         * 
         * */
        public static int GetSessionCount()
        {
            int res = 0;
            if (activeSessionList != null)
            {
                res = activeSessionList.Count;
            }
            return res;
        }

        /**
         * 
         * <summary>��һ���µĻỰ</summary>
         * 
         * 
         * */
        public NHibernate.ISession getSession()
        {
            /*
            if (sessionFactory == null)
            {
                Configuration config = new Configuration().Configure();
                sessionFactory = config.BuildSessionFactory();
                if (activeSessionList != null)
                {
                    for (int i = 0; i < activeSessionList.Count; i++)
                    {
                        ISession s = (ISession)activeSessionList[i];
                        if (s == null)
                            continue;
                        if (s.IsOpen == true)
                        {
                            s.Close();
                        }
                    }
                    activeSessionList.Clear();
                }
                activeSessionList = new ArrayList(10);
            }
            ISession newSession = sessionFactory.OpenSession();
            activeSessionList.Add(newSession);
            return newSession;
            */
            if (sessionFactory == null)
            {
                if (!string.IsNullOrEmpty(DBConnectionString))
                {
                    Configuration config = new Configuration();
                    IDictionary<string, string> hash = new Dictionary<string, string>();

                    //hash.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    hash.Add("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                    hash.Add("dialect", "NHibernate.Dialect.MsSql2005Dialect");
                    string strConn = DBConnectionString;//DESSecurity.Decrypt(DBConnectionString);
                    //"Data Source=localhost;Persist Security Info=True;Password=hdrft;User ID=sa;Initial Catalog=BusTicket"
                    hash.Add("connection.connection_string", strConn);
                    //hash.Add("use_outer_join", "true");
                    //hash.Add("query.substitutions", "true 1, false 0, yes 'Y', no 'N'");
                    config.AddProperties(hash);
                    config.AddAssembly("BusTicketData");
                    config.SetDefaultAssembly("BusTicketData");

                    sessionFactory = config.BuildSessionFactory();
                }
                else
                {
                    try
                    {
                        Configuration config = new Configuration().Configure();
                        sessionFactory = config.BuildSessionFactory();
                    }
                    catch (System.Exception ex)
                    {//NHibernate.Bytecode.UnableToLoadProxyFactoryFactoryException
                        Console.WriteLine(ex.Message);                    	
                    }

                }
            }
            ISession session = sessionFactory.OpenSession();
            return session;
            /*
            if (sessionInstance == null || !sessionInstance.IsConnected || !sessionInstance.IsOpen)
            {
                sessionInstance = sessionFactory.OpenSession();
            }

            return sessionInstance;
             * */
           
        }
        /**
         * <summary>�رջỰ������getSession��������ISession������ʹ����ö�������ִ�и÷�����ʾ�Ĺرյ�ǰ�Ự</summary>
         * <param name="session">����getSession()�������ص�ISessiond����
         * */
        public void CloseSession(ISession session)
        {
            if (session == null)
                return;
            if (session.IsOpen)
            {
                if (activeSessionList != null)
                {
                    for (int i = 0; i < activeSessionList.Count; i++)
                    {
                        if (session == activeSessionList[i])
                        {
                            activeSessionList.RemoveAt(i);
                            break;
                        }
                    }
                }

                session.Close();
            }

        }


        /// <summary>
        /// ����ָ����hql���ִ�����ݿ��ѯ
        /// </summary>
        /// <param name="hql">hql��ѯ���</param>
        /// <returns>����hql���Ĳ�ѯ����б����</returns>
        public System.Collections.IList Query(string hql)
        {
            try
            {
                ISession s = this.getSession();
                IQuery q = s.CreateQuery(hql);
                System.Collections.IList list = q.List();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }

                return list;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                return null;
            }


        }

        /// <summary>
        /// �����ݿ��в�ѯָ������ֵ�����ݿ��¼����
        /// </summary>
        /// <param name="clazz">�������ͣ��磺typeof(AssetHibernate.PropDict)</param>
        /// <param name="keyValue">Ҫ��ѯ�����ݿ��¼������ֵ</param>
        /// <returns></returns>
        public object GetObject(Type clazz, object keyValue)
        {
            object o = null;
            ISession s = this.getSession();
            if (s == null)
                return null;
            try
            {
                o = s.Get(clazz, keyValue);

            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
            }

            return o;
        }
        /// <summary>
        /// �����ݿ��в�ѯָ������ֵ�����ݿ��¼����
        /// </summary>
        /// <param name="clazz">�������ͣ��磺typeof(AssetHibernate.PropDict)</param>
        /// <param name="keyValue">Ҫ��ѯ�����ݿ��¼������ֵ</param>
        /// <param name="session">session������Ҫ���ⲿ�ر�session</param>
        /// <returns></returns>
        public object GetObjectSession(Type clazz, object keyValue, ref ISession session)
        {
            object o = null;
            ISession s = null;
            if (session != null)
            {
                s = session;
            }
            else
            {
                s = this.getSession();
                session = s;
            }

            if (s == null)
                return null;
            try
            {
                o = s.Get(clazz, keyValue);
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                this.CloseSession(s);
                session = null;
                Console.WriteLine(ex.Message);
            }
            return o;
        }
        /**
         * <summary>
         * ���¶������ݿ�
         * </summary>
         * <param name="obj">Ҫ���µ����ݿ��¼����</param>
         * */
        public bool Update(object obj)
        {
            ISession s = this.getSession();
            if (s == null)
                return false;
            try
            {
                NHibernate.ITransaction trans = s.BeginTransaction();
                //s.Update(s.Merge(obj));
                object mobj = null;
                try
                {
                    mobj = s.Merge(obj);
                }
                catch (Exception me)
                {
                    mobj = obj;
                }
                s.Clear();
                s.Update(mobj);
                trans.Commit();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
                return true;
            }
            catch (System.Exception e)
            {
                this._lastError = e.Message;
                this.lastException = e;
                Console.WriteLine(e.Message);
                return false;
            }

        }
        /**
         * <summary>����������ݿ�</summary>
         * <param name="obj">Ҫ��������ݿ��¼����</param>
         * 
         * 
         * */
        public bool Save(object obj)
        {
            ISession s = this.getSession();
            if (s == null)
                return false;
            ITransaction trans = s.BeginTransaction();
            try
            {

                //s.Save(s.Merge(obj));
                s.Clear();
                s.Save(obj);
                trans.Commit();
                s.Flush();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
                return true;
            }
            catch (System.Exception e)
            {
                trans.Rollback();
                Console.WriteLine("NHibernateHelper.Save method failed:{0}",e.Message);
                this._lastError = e.Message;
                this.lastException = e;
                return false;
            }
        }
        public bool UpdateBlob(string hql, byte[] blobData,string p_name)
        {
            try
            {
                ISession s = this.getSession();

                System.Data.IDbCommand cmd = s.Connection.CreateCommand();
                cmd.CommandText = hql;
                System.Data.IDbDataParameter param = cmd.CreateParameter();
                param.DbType = System.Data.DbType.Binary;
                param.Value = blobData;
                param.Direction = System.Data.ParameterDirection.Input;
                param.ParameterName = p_name;
                cmd.Parameters.Add(param);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    if (AutoCloseSession)
                    {
                        this.CloseSession(s);
                    }
                    return true;
                }
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
                return false;
            }
            catch (Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                return false;
            }
 

        }
        /// <summary>
        /// ִ��ԭʼsql����
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecSqlCmd(string sql, List<System.Data.IDbDataParameter> parameters)
        {
            int result = 0;
            ISession s = this.getSession();
            IDbTransaction trans = s.Connection.BeginTransaction();
            try
            {
                System.Data.IDbCommand cmd = s.Connection.CreateCommand();
                cmd.Transaction = trans;
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (System.Data.IDbDataParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                result = cmd.ExecuteNonQuery();
                trans.Commit();
                return result;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;

                trans.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
            }
            return result;

        }

        public DataTable ExecSqlQuery(string sql, List<System.Data.IDbDataParameter> parameters)
        {
            ISession s = this.getSession();
            DataTable table = null;
            try
            {
                System.Data.IDbCommand cmd = s.Connection.CreateCommand();
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (System.Data.IDbDataParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                IDataReader reader = cmd.ExecuteReader();
                table = new DataTable();
                table.Load(reader);

                //                 while (reader.Read())
                //                 {
                //                     DataRow r = table.NewRow();
                //                     for (int i = 0; i < reader.FieldCount; i++)
                //                     {
                //                         r[i] = reader.GetValue(i);
                //                     }
                //                     table.Rows.Add(r);                   
                //                 }
                return table;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
            }
            return table;

        }
        public IDataReader ExecSqlQuery(string sql, List<System.Data.IDbDataParameter> parameters, ref ISession session)
        {
            session = this.getSession();
            IDataReader reader = null;
            try
            {
                System.Data.IDbCommand cmd = session.Connection.CreateCommand();
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (System.Data.IDbDataParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                Console.WriteLine(ex.Message);
            }
            return reader;

        }

        /**
         * <summary>
         * �����ݿ���ɾ��ָ���Ķ����¼
         * </summary>
         * <param name="obj">Ҫɾ���Ķ���</param>
         * 
         * 
         * */
        public bool Delete(object obj)
        {
            ISession s = this.getSession();
            if (s == null)
            {
                return false;
            }
            try
            {
                ITransaction trans = s.BeginTransaction();
                s.Delete(s.Merge(obj));
                trans.Commit();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
            }
            catch (System.Exception ee)
            {
                this._lastError = ee.Message;
                this.lastException = ee;
                Console.WriteLine(ee.Message);
                return false;
            }
            return true;
        }
        public int DeleteFromHQL(string query)
        {
            int res = -1;
            ISession s = this.getSession();
            if (s == null)
            {
                return res;
            }
            try
            {
                ITransaction trans = s.BeginTransaction();
                res = s.Delete(query);
                trans.Commit();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
            }
            catch (System.Exception ee)
            {
                this._lastError = ee.Message;
                this.lastException = ee;
                Console.WriteLine(ee.Message);
                return -1;
            }
            return res;
        }
        /// <summary>
        /// ������ͨ���Ͷ�����ʹ��paramters����
        /// ����������͵����ԣ�ʹ��pojo����
        /// </summary>
        /// <param name="hql">hql��ѯ���</param>
        /// <param name="parameters">��hql�еĲ�ѯ�������Ӧ�Ĳ���ֵ����</param>
        /// <param name="pojo">��ʹ�ø�����ʱ��hql�е������������Ʊ�����������һ�£�����������ѯ����</param>
        /// <returns></returns>
        ///         

        public int GetRowCount(string hql, ArrayList parameters, object pojo)
        {
            try
            {
                ISession s = this.getSession();
                IQuery q = s.CreateQuery(hql);
                if (parameters != null)
                {
                    if (parameters.Count > 0)
                    {
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            q.SetParameter(i, parameters[i]);
                        }
                    }
                }
                if (pojo != null)
                {
                    q.SetProperties(pojo);
                }
                IList list = q.List();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }
                long rows = (long)list[0];
                return (int)rows;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                return 0;
            }

        }

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="hql">��ѯhql���</param>
        /// <param name="parameters">hql�д��ݵĲ���ֵ����</param>
        /// <param name="pojo">Properties��������</param>
        /// <param name="pageIndex">Ҫ��ѯ��ҳ����������0��ʼ����</param>
        /// <param name="pageRowCount">ÿҳ����������ֵС��1ʱ������������</param>      
        /// <param name="pageRowCount">���������ӣ���ͨ���ò����������ӻỰ��Ϣ</param>
        /// <returns></returns>
        public System.Collections.IList QueryByPageIndex(string hql, ArrayList parameters, object pojo, int pageIndex, int pageRowCount)
        {

            ISession s = this.getSession();
            try
            {
                IQuery q = s.CreateQuery(hql);
                if (parameters != null)
                {
                    if (parameters.Count > 0)
                    {
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            q.SetParameter(i, parameters[i]);

                        }
                    }
                }
                if (pojo != null)
                {
                    q.SetProperties(pojo);
                }
                if (pageRowCount > 0)
                {
                    if (pageIndex < 0)
                        pageIndex = 0;
                    q.SetFirstResult(pageIndex * pageRowCount);
                    q.SetMaxResults(pageRowCount);
                }
                IList list = q.List();
                if (AutoCloseSession)
                {
                    this.CloseSession(s);
                }

                return list;
            }
            catch (System.Exception ex)
            {
                this._lastError = ex.Message;
                this.lastException = ex;
                return null;
            }

        }
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="hql">��ѯhql���</param>
        /// <param name="parameters">hql�д��ݵĲ���ֵ����</param>
        /// <param name="pojo">Properties��������</param>
        /// <param name="pageIndex">Ҫ��ѯ��ҳ����������0��ʼ����</param>
        /// <param name="pageRowCount">ÿҳ����������ֵС��1ʱ������������</param>       
        /// <param name="pageRowCount">���������ӣ���ͨ���ò����������ӻỰ��Ϣ</param>
        /// <returns></returns>
        public System.Collections.IList QueryByPageIndexSession(string hql, ArrayList parameters, object pojo, int pageIndex, int pageRowCount, ref ISession session)
        {
            session = null;
            ISession s = null;
            if (session != null)
            {
                s = session;
            }
            else
            {
                s = this.getSession();
                session = s;
            }
            IQuery q = s.CreateQuery(hql);
            if (parameters != null)
            {
                if (parameters.Count > 0)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        q.SetParameter(i, parameters[i]);

                    }
                }
            }
            if (pojo != null)
            {
                q.SetProperties(pojo);
            }
            if (pageRowCount > 0)
            {
                if (pageIndex < 0)
                    pageIndex = 0;
                q.SetFirstResult(pageIndex * pageRowCount);
                q.SetMaxResults(pageRowCount);
            }
            IList list = q.List();
            return list;
        }

        /// <summary>
        /// ��ȡ��󵥺ű��롣����Ϊ12λ�ַ��ͣ���������Ϊ: xx(����������д)xxxx(��)xx(��)xxxx(4λ��ˮ��)
        /// </summary>
        /// <param name="tableName">���������</param>
        /// <param name="keyFieldName">�����ֶ�����</param>
        /// <param name="prefix">����������д������ǰ׺�������Դ˿�ͷ��</param>
        /// <param name="year">���</param>
        /// <param name="month">�·�</param>
        /// <returns>���ع������</returns>

        public string GetMaxBillNo(string tableName, string keyFieldName, string prefix, int year, int month)
        {
            string prefixNo = prefix + year.ToString("0000") + month.ToString("00");
            string hql = "select max(tb." + keyFieldName + ") From  " + tableName + "  tb where tb." + keyFieldName + " like '" + prefixNo + "%'";
            System.Collections.IList list = this.Query(hql);
            string billNo = "";
            if (list.Count > 0 && list[0] != null)
            {
                billNo = list[0].ToString();
            }
            else
            {
                billNo = prefixNo + "0000";
            }
            int index = int.Parse(billNo.Substring(8));
            index++;
            billNo = prefixNo + index.ToString("0000");
            return billNo;

        }

        /// <summary>
        /// ��ȡ����¼�š�(ֻ����������ֶ�ֵ)
        /// </summary>
        /// <param name="tableName">���������</param>
        /// <param name="keyFieldName">�����ֶ�����</param>
        /// <returns></returns>
        public int GetMaxId(string tableName, string keyFieldName)
        {
            int id = 0;
            string hql = "select max(tb." + keyFieldName + ") From  " + tableName + " as  tb ";
            System.Collections.IList list = this.Query(hql);
            if (list.Count > 0)
            {
                object obj = list[0];
                if (obj != null)
                {
                    id = Convert.ToInt32(obj);
                }
            }
            id++;
            return id;
        }
        public int GetNextSequence(string strSequenceName)
        {
            ISession s = this.getSession();
            if (s == null)
                return 0;
            int id = 0;            
            string hql = "select " + strSequenceName + ".nextval from dual";
            IDataReader reader = this.ExecSqlQuery(hql, null, ref s);
            if (reader != null && reader.Read())
            {
                id = reader[0] == null ? 1 : Convert.ToInt32(reader[0]);                
            }
            reader.Close();
            if (AutoCloseSession)
            {
                this.CloseSession(s);
            }
            return id;
        }
    }
}
