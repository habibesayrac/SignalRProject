﻿using SignalR.DatatAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaDal
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void Delete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia GetByID(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public List<SocialMedia> GetListAll()
        {
           return _socialMediaDal.GetListAll();
        }

        public void Update(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}