using System;
using System.ComponentModel;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DNE.WebMedia.Model
{

public partial class Translate:ICloneable
{
//---------- Generated ----------

        #region CRUD
        
        /// <summary>
        /// Add current object to db
        /// </summary>
        public void Add()
        {
            HQEntities db = new HQEntities();
            db.AddToTranslate(this);
            db.SaveChanges();

        }

        /// <summary>
        /// Remove current object from db
        /// </summary>
        public void Delete()
        {
            HQEntities db = new HQEntities();
            db.DeleteObject(db.Translate.Where(x => x.Id == this.Id).First());
            db.SaveChanges();

        }
        
        #endregion
        
        #region static Methods
          
        /// <summary>
        /// Get an Translate object by key
        /// </summary>
        /// <param name="Id">Primary key</param>
        /// <param name="Fill">Get Related objects</param>
        /// <returns>A Translate object</returns>
        public static Translate GetOne(System.Int64 Id ,bool Fill)
        {
            HQEntities db = new HQEntities();
            return db.Translate.Include("Aya").Where(e => e.Id == Id).First();
            
        }
        
        /// <summary>
        /// Get all object in Translate Table
        /// without related objects
        /// </summary>
        /// <returns>Return Translate Table</returns>
        public static IQueryable<Translate> GetAll() 
        {
            HQEntities db = new HQEntities();
            return db.Translate.Include("Aya").OrderByDescending(x=>x.Id);
            
        }
        
        /// <summary>
        /// Usefull in webpages that need to pagination data
        /// </summary>
        /// <param name="CurrentPage">Current Page Number in Repeater or Grid</param>
        /// <param name="RowPerPage">Row Count per Page</param>
        /// <param name="TotalRows">will return total row count, this may uses by pager</param>
        /// <returns>An IQueryable list of Translate </returns>
        public static IQueryable<Translate> GetPaged(Int32 CurrentPage, Int32 RowPerPage, ref Int32 TotalRows)
        {
            HQEntities db = new HQEntities();
            TotalRows = db.Translate.Count();
            return db.Translate.Include("Aya").OrderByDescending(x=>x.Id).Skip((CurrentPage - 1) * RowPerPage).Take(RowPerPage);
        }
    
        #endregion

        #region Clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>

        /// A new object that is a copy of this instance.
        /// </returns>
        private object ICloneable_Clone()
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Translate));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                return serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <remarks>
        /// This method is equivalent to a Detach from the current DataContext/>.
        /// Only loaded EntityRef and EntitySet child accessions will be cloned.
        /// </remarks>
        object ICloneable.Clone()
        {
            return ICloneable_Clone();
        }



        /// <summary>
        /// Create a new object but just copy main fields, no related tables
        /// </summary>
        /// <returns>
        /// A new Translate object 
        /// </returns>
        /// <remarks></remarks>
        public Translate CloneSimple()
        {
            Translate copy = new Translate();
            copy.Id = this.Id;
            copy.LangId = this.LangId;
            copy.Lang = this.Lang;
            copy.TranslatedBy = this.TranslatedBy;
            copy.Text = this.Text;
            copy.Direction = this.Direction;
            return copy;
        }

        #endregion

        #region  Serialization 

        private bool serializing = false;

        /// <summary>
        /// Called when serializing.
        /// </summary>
        /// <param name="context">The <see cref="StreamingContext"/> for the serialization.</param>
        [OnSerializing(), EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnSerializing(StreamingContext context)
        {
            serializing = true;
        }

        /// <summary>
        /// Called when serializing completed.
        /// </summary>
        /// <param name="context">The <see cref="StreamingContext"/> for the serialization.</param>
        [OnSerialized(), EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnSerialized(StreamingContext context)
        {
            serializing = false;
        }

        /// <summary>
        /// Called when deserializing.
        /// </summary>
        /// <param name="context">The <see cref="StreamingContext"/> for the serialization.</param>
        [OnDeserializing(), EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public void OnDeserializing(StreamingContext context)
        {
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Translate"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Translate"/> instance.</param>
        /// <returns>An instance of <see cref="Translate"/> that is deserialized from the XML string.</returns>
        public static Translate FromXml(string xml)
        {
            var deserializer = new DataContractSerializer(typeof(Translate));
            using (StringReader sr = new StringReader(xml))
            {
                using (XmlReader reader = XmlReader.Create(sr))
                {
                    return deserializer.ReadObject(reader) as Translate;
                }
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Translate"/>.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Translate"/> instance.</param>
        /// <returns>An instance of <see cref="Translate"/> that is deserialized from the byte array.</returns>
        public static Translate FromBinary(byte[] buffer)
        {
            var deserializer = new DataContractSerializer(typeof(Translate));
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max))
                {
                    return deserializer.ReadObject(reader) as Translate;
                }
            }
        }

        /// <summary>
        /// Serializes an instance of <see cref="Translate"/>.
        /// </summary>
        /// <returns>Byte array</returns>
        public byte[] ToBinary()
        {
            var serializer = new DataContractSerializer(typeof(Translate));
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlDictionaryWriter reader = XmlDictionaryWriter.CreateBinaryWriter(ms))
                {

                    serializer.WriteObject(reader, this);
                }
                return ms.ToArray();
            }
        }

        #endregion
        
    }
 }
