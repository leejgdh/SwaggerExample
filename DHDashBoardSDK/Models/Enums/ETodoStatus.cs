using System.Runtime.Serialization;

namespace SwaggerExample.Models.Enums
{
    public enum ETodoStatus
    {
        /// <summary>
        /// 대기
        /// </summary>
        [EnumMember(Value ="READY")]
        READY,
        /// <summary>
        /// 활성화
        /// </summary>
        ACTIVE,
        /// <summary>
        /// 삭제됨
        /// </summary>
        DELETED
    }
}
