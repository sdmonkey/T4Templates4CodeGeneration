 
// Template Genearated Content - syntax-highlighting but no intellisense
// Template: C:\Users\sdmonkey\source\repos\MyProject\ProjToken.Business\UnitOfWork.tt; 
// Created: 8/29/2018 5:11:11 PM
using MyProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models.UnitOfWork
{
	public interface IProjectFunctionUow
	{
		IFunctionRepository FunctionRepository{ get; }
		IFunctionSettingsRepository FunctionSettingsRepository{ get; }
		IOtherRepository OtherRepository{ get; }
		void Dispose();
	}
	public class ProjectFunctionUow : IDisposable, IProjectFunctionUow
	{
		private readonly IFunctionRepository _functionRepository;
		private IFunctionSettingsRepository _functionSettingsRepository;
		private IOtherRepository _otherRepository;

		public ProjectFunctionUow()
		{
			_functionRepository = new FunctionRepository();
			_functionSettingsRepository = new FunctionSettingsRepository();
			_otherRepository = new OtherRepository();
		}
		public IFunctionRepository FunctionRepository
		{
			get {
				return _functionRepository;
			}
		}
		public IFunctionSettingsRepository FunctionSettingsRepository
		{
			get
			{
				return _functionSettingsRepository ??
				(_functionSettingsRepository = new FunctionSettingsRepository(_functionRepository.Connection));
			}

		}
		public IOtherRepository OtherRepository
		{
			get
			{
				return _otherRepository ??
				(_otherRepository = new OtherRepository(_functionRepository.Connection));
			}

		}

		#region Dispose / Garbage Collection

		private bool _disposed;

		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				if (disposing)
				{
					 _functionRepository.Dispose();

					if (_functionSettingsRepository != null)
						_functionSettingsRepository.Dispose();

					if (_otherRepository != null)
						_otherRepository.Dispose();

				}
			}

			_disposed = true;
		}

        /// <summary>
        ///     Releases the resource used by the object context
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
 
