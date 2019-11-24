using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LogicBuilder.Attributes;


namespace Contoso.Domain.Entities
{
    public class CourseAssignmentModel : BaseModelClass
    {
		[VariableEditorControl(VariableControlType.SingleLineTextBox)]
		[AlsoKnownAs("CourseAssignment_InstructorID")]
		public int InstructorID { get; set; }

		[VariableEditorControl(VariableControlType.SingleLineTextBox)]
		[AlsoKnownAs("CourseAssignment_CourseID")]
		public int CourseID { get; set; }

		[AlsoKnownAs("CourseAssignment_Instructor")]
		public InstructorModel Instructor { get; set; }

		[AlsoKnownAs("CourseAssignment_Course")]
		public CourseModel Course { get; set; }
    }
}