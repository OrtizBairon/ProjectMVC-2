﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMVC.LOGICA.BL
{
    public class Tasks
    {

        /// <summary>
        /// GET TASKS
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        public List<Models.DB.Tasks> GetTasks(int? projectId,
            int? Id)
        {
            DAL.Models.PROJECTMVCEntities _context = new DAL.Models.PROJECTMVCEntities();

            var listTasks = (from _Tasks in _context.Tasks
                             join _states in _context.States on _Tasks.StateId equals _states.Id
                             join _activities in _context.Activities on _Tasks.ActivityId equals _activities.Id
                             join _priorities in _context.Priorities on _Tasks.PriorityId equals _priorities.Id
                             select new Models.DB.Tasks
                             {
                                 Id = _Tasks.Id,
                                 Title = _Tasks.Title,
                                 Details = _Tasks.Details,
                                 ExpirationDate = _Tasks.ExpirationDate,
                                 IsCompleted = _Tasks.IsCompleted,
                                 Effort = _Tasks.Effort,
                                 RemainingWork = _Tasks.RemainingWork,

                                 StateId = _Tasks.StateId,
                                 states = new Models.DB.States
                                 {
                                     Name = _states.Name
                                 },

                                 ActivityId = _Tasks.ActivityId,
                                 Activities = new Models.DB.Activities
                                 {
                                     Name = _activities.Name
                                 },

                                 PriorityId = _Tasks.PriorityId,
                                 Priorities = new Models.DB.Priorities
                                 {
                                     Name = _priorities.Name
                                 },

                                 ProjectId = _Tasks.ProjectId,
                                
                             }).ToList();

            if (projectId != null)
                listTasks = listTasks.Where(x => x.ProjectId == projectId).ToList();
            if (Id != null)
                listTasks = listTasks.Where(x => x.Id == Id).ToList();

            return listTasks;
        }

        /// <summary>
        /// CREATE TASKS
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expirationDate"></param>
        /// <param name="isCompleted"></param>
        /// <param name="effort"></param>
        /// <param name="remainingWork"></param>
        /// <param name="statedId"></param>
        /// <param name="activityId"></param>
        /// <param name="priorityId"></param>
        /// <param name="projectId"></param>
        ///

        public void CreateTasks(string title,
            string details,
            DateTime? expirationDate,
            bool isCompleted,
            int? effort,
            int? remainingWork,
            int? statedId,
            int? activityId,
            int? priorityId,
            int? projectId)
        {
            DAL.Models.PROJECTMVCEntities _context = new DAL.Models.PROJECTMVCEntities();

            _context.Tasks.Add(new DAL.Models.Tasks
            {
                Title = title,
                Details = details,
                ExpirationDate = expirationDate,
                IsCompleted = isCompleted,
                Effort = effort,
                RemainingWork = remainingWork,
                StateId = statedId,
                ActivityId = activityId,
                PriorityId = priorityId,
                ProjectId = projectId
            });

            _context.SaveChanges();
        }
    }
}
