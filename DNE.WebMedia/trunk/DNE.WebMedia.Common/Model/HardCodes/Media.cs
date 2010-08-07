using System;
using System.ComponentModel;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace DNE.WebMedia.Model
{

public partial class Media:ICloneable
{
//---------- Generated ----------

        #region CRUD
        
        /// <summary>
        /// Add current object to db
        /// </summary>
        public void Add()
        {
            HQEntities db = new HQEntities();
            db.AddToMedia(this);
            db.SaveChanges();

        }

        /// <summary>
        /// Remove current object from db
        /// </summary>
        public void Delete()
        {
            HQEntities db = new HQEntities();
            db.DeleteObject(db.Media.Where(x => x.Id == this.Id).First());
            db.SaveChanges();

        }
        
        #endregion
        
        #region static Methods
          
        /// <summary>
        /// Get an Media object by key
        /// </summary>
        /// <param name="Id">Primary key</param>
        /// <param name="Fill">Get Related objects</param>
        /// <returns>A Media object</returns>
        public static Media GetOne(System.Int64 Id )
        {
            HQEntities db = new HQEntities();
            return db.Media.Where(e => e.Id == Id).First();
            
        }
        
        /// <summary>
        /// Get all object in Media Table
        /// without related objects
        /// </summary>
        /// <returns>Return Media Table</returns>
        public static IQueryable<Media> GetAll() 
        {
            HQEntities db = new HQEntities();
            return db.Media.OrderByDescending(x=>x.Id);
            
        }
        
        /// <summary>
        /// Usefull in webpages that need to pagination data
        /// </summary>
        /// <param name="CurrentPage">Current Page Number in Repeater or Grid</param>
        /// <param name="RowPerPage">Row Count per Page</param>
        /// <param name="TotalRows">will return total row count, this may uses by pager</param>
        /// <returns>An IQueryable list of Media </returns>
        public static IQueryable<Media> GetPaged(Int32 CurrentPage, Int32 RowPerPage, ref Int32 TotalRows)
        {
            HQEntities db = new HQEntities();
            TotalRows = db.Media.Count();
            return db.Media.OrderByDescending(x=>x.Id).Skip((CurrentPage - 1) * RowPerPage).Take(RowPerPage);
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
            DataContractSerializer serializer = new DataContractSerializer(typeof(Media));
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
        /// A new Media object 
        /// </returns>
        /// <remarks></remarks>
        public Media CloneSimple()
        {
            Media copy = new Media();
            copy.Id = this.Id;
            copy.Title = this.Title;
            copy.Story = this.Story;
            copy.Body = this.Body;
            copy.UserName = this.UserName;
            copy.AddDate = this.AddDate;
            copy.EditDate = this.EditDate;
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
        /// Deserializes an instance of <see cref="Media"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Media"/> instance.</param>
        /// <returns>An instance of <see cref="Media"/> that is deserialized from the XML string.</returns>
        public static Media FromXml(string xml)
        {
            var deserializer = new DataContractSerializer(typeof(Media));
            using (StringReader sr = new StringReader(xml))
            {
                using (XmlReader reader = XmlReader.Create(sr))
                {
                    return deserializer.ReadObject(reader) as Media;
                }
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Media"/>.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Media"/> instance.</param>
        /// <returns>An instance of <see cref="Media"/> that is deserialized from the byte array.</returns>
        public static Media FromBinary(byte[] buffer)
        {
            var deserializer = new DataContractSerializer(typeof(Media));
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max))
                {
                    return deserializer.ReadObject(reader) as Media;
                }
            }
        }

        /// <summary>
        /// Serializes an instance of <see cref="Media"/>.
        /// </summary>
        /// <returns>Byte array</returns>
        public byte[] ToBinary()
        {
            var serializer = new DataContractSerializer(typeof(Media));
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
