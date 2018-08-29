<#@ template debug="true" hostSpecific="true" #>
<#@ output extension=".cs" #>
<#@ Assembly Name="System.Core.dll" #>
<#@ Assembly Name="System.Windows.Forms.dll" #>
<#@ import namespace="System" #>
<#@ import namespace="System.Collections" #>
<#@ import namespace="System.Collections.Generic" #> 
<#@ import namespace="System.Diagnostics" #>
<#@ import namespace="System.IO" #>
<#   
	//Template Code here. - you get IntelliSense here
	//You could create variables here or retrieve data from some other sources
	string projName = "MyProject";
	string uowName = "ProjectFunctionUow";
	string[] repos = {"FunctionRepository","FunctionSettingsRepository","OtherRepository"};
#>
// Template Genearated Content - syntax-highlighting but no intellisense
// Template: <#= Host.TemplateFile #>; 
// Created: <#= System.DateTime.Now.ToString() #>
using <#=projName#>.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace <#=projName#>.Models.UnitOfWork
{
	public interface I<#=uowName#>
	{
<# generateInterfaces(repos); #>
		void Dispose();
	}
	public class <#= uowName #> : IDisposable, I<#= uowName #>
	{
<# generateClassInterfaceInstantiation(repos); #>

		public <#= uowName #>()
		{
<# generateClassConstructor(repos); #>
		}
<# generateClassMethods(repos); #>

		#region Dispose / Garbage Collection

		private bool _disposed;

		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				if (disposing)
				{
<# generateClassDisposers(repos); #>
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
 
<#+  
// Insert any template procedures here

void generateInterfaces(string[] repos) {
	foreach (string clss in repos) {
		WriteLine("\t\tI" + clss + " " + clss + "{ get; }" );
    }
}
void generateClassInterfaceInstantiation(string[] repos) {
	int counter = 0;
	foreach (string clss in repos) {
		Write("\t\tprivate ");
		if(counter == 0){
			Write("readonly " );
        }
		Write("I" + clss + " _" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + ";" );
		Write("\n");
		counter++;
    }
}
void generateClassConstructor(string[] repos) {
	foreach (string clss in repos) {
		WriteLine("\t\t\t_" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + " = new " + clss + "();" );
    }
}
void generateClassMethods(string[] repos) {
	int counter = 0;
	foreach (string clss in repos) {
		WriteLine("\t\tpublic I" + clss + " " + clss);
		WriteLine("\t\t{");
		if(counter == 0){
			Write("\t\t\tget {\n\t\t\t\t");
			Write("return _" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + ";\n\t\t\t}" );
        }else{
			WriteLine("\t\t\tget");
			WriteLine("\t\t\t{");
			WriteLine("\t\t\t\treturn _" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + " ??");
			WriteLine("\t\t\t\t(_" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + " = new " + clss + "(_" + repos[0].Substring(0,1).ToLower() + repos[0].Substring(1,repos[0].Length-1) + ".Connection));");
			WriteLine("\t\t\t}");
        }
		Write("\n\t\t}\n");
		counter++;
    }
}
void generateClassDisposers(string[] repos) {
	int counter = 0;
	foreach (string clss in repos) {
		if(counter == 0){
			WriteLine("\t\t\t\t\t _" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + ".Dispose();\n" );
        }else{
			WriteLine("\t\t\t\t\tif (_" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + " != null)");
			WriteLine("\t\t\t\t\t\t_" + clss.Substring(0,1).ToLower() + clss.Substring(1,clss.Length-1) + ".Dispose();\n");
        }
		counter++;
    }
}
#>
