using System;
using System.Collections.Generic;
using System.Text;

namespace io.rong.util
{
    public class CodeUtil
    {

        /// <summary>
        /// 会话类型
        /// </summary>
        public sealed class ConversationType
        {
            //二人会话
            public static readonly ConversationType PRIVATE = new ConversationType("PRIVATE", InnerEnum.PRIVATE, "1");
            //讨论组会话
            public static readonly ConversationType DISCUSSION = new ConversationType("DISCUSSION", InnerEnum.DISCUSSION, "2");
            //群组会话
            public static readonly ConversationType GROUP = new ConversationType("GROUP", InnerEnum.GROUP, "3");
            //系统通知
            public static readonly ConversationType SYSTEM = new ConversationType("SYSTEM", InnerEnum.SYSTEM, "6");
            //客服会话
            public static readonly ConversationType KF = new ConversationType("KF", InnerEnum.KF, "5");
            //应用公众服务
            public static readonly ConversationType MC = new ConversationType("MC", InnerEnum.MC, "7");
            //公众服务
            public static readonly ConversationType MP = new ConversationType("MP", InnerEnum.MP, "8");

            private static readonly IList<ConversationType> valueList = new List<ConversationType>();

            static ConversationType()
            {
                valueList.Add(PRIVATE);
                valueList.Add(DISCUSSION);
                valueList.Add(GROUP);
                valueList.Add(SYSTEM);
                valueList.Add(KF);
                valueList.Add(MC);
                valueList.Add(MP);
            }

            public enum InnerEnum
            {
                PRIVATE,
                DISCUSSION,
                GROUP,
                SYSTEM,
                KF,
                MC,
                MP
            }

            public readonly InnerEnum innerEnumValue;
            private readonly string nameValue;
            private readonly int ordinalValue;
            private static int nextOrdinal = 0;


            internal string name;
            internal ConversationType(string nameValue, InnerEnum innerEnum, string name)
            {
                this.name = name;

                this.nameValue = nameValue;
                ordinalValue = nextOrdinal++;
                innerEnumValue = innerEnum;
            }
            public string Name
            {
                get
                {
                    return this.name;
                }
            }

            public static IList<ConversationType> values()
            {
                return valueList;
            }

            public int ordinal()
            {
                return ordinalValue;
            }

            public override string ToString()
            {
                return nameValue;
            }

            public static ConversationType valueOf(string name)
            {
                foreach (ConversationType enumInstance in ConversationType.valueList)
                {
                    if (enumInstance.nameValue == name)
                    {
                        return enumInstance;
                    }
                }
                throw new System.ArgumentException(name);
            }
        }

        public sealed class ServiceType
        {
            public static readonly ServiceType chatRoom = new ServiceType("chatRoom", InnerEnum.chatRoom, 1);
            public static readonly ServiceType group = new ServiceType("group", InnerEnum.group, 2);
            public static readonly ServiceType message = new ServiceType("message", InnerEnum.message, 3);
            public static readonly ServiceType push = new ServiceType("push", InnerEnum.push, 4);
            public static readonly ServiceType sensitiveword = new ServiceType("sensitiveword", InnerEnum.sensitiveword, 5);
            public static readonly ServiceType sms = new ServiceType("sms", InnerEnum.sms, 6);
            public static readonly ServiceType user = new ServiceType("user", InnerEnum.user, 7);
            public static readonly ServiceType worefilter = new ServiceType("worefilter", InnerEnum.worefilter, 8);

            private static readonly IList<ServiceType> valueList = new List<ServiceType>();

            static ServiceType()
            {
                valueList.Add(chatRoom);
                valueList.Add(group);
                valueList.Add(message);
                valueList.Add(push);
                valueList.Add(sensitiveword);
                valueList.Add(sms);
                valueList.Add(user);
                valueList.Add(worefilter);
            }

            public enum InnerEnum
            {
                chatRoom,
                group,
                message,
                push,
                sensitiveword,
                sms,
                user,
                worefilter
            }

            public readonly InnerEnum innerEnumValue;
            private readonly string nameValue;
            private readonly int ordinalValue;
            private static int nextOrdinal = 0;

            internal int resultCode;

            internal ServiceType(string name, InnerEnum innerEnum, int resultCode)
            {
                this.resultCode = resultCode;
                this.nameValue = name;
                ordinalValue = nextOrdinal++;
                innerEnumValue = innerEnum;
            }
            public int ResutCode
            {
                get
                {
                    return this.resultCode;
                }
            }

            public static IList<ServiceType> values()
            {
                return valueList;
            }

            public int ordinal()
            {
                return ordinalValue;
            }

            public override string ToString()
            {
                return nameValue;
            }

            public static ServiceType valueOf(string name)
            {
                foreach (ServiceType enumInstance in ServiceType.valueList)
                {
                    if (enumInstance.nameValue == name)
                    {
                        return enumInstance;
                    }
                }
                throw new System.ArgumentException(name);
            }
        }

        public sealed class ErrorType
        {
            public static readonly ErrorType chatRoom = new ErrorType("chatRoom", InnerEnum.chatRoom, 1);
            public static readonly ErrorType group = new ErrorType("group", InnerEnum.group, 2);
            public static readonly ErrorType message = new ErrorType("message", InnerEnum.message, 3);
            public static readonly ErrorType push = new ErrorType("push", InnerEnum.push, 4);
            public static readonly ErrorType sensitiveword = new ErrorType("sensitiveword", InnerEnum.sensitiveword, 5);
            public static readonly ErrorType sms = new ErrorType("sms", InnerEnum.sms, 6);
            public static readonly ErrorType user = new ErrorType("user", InnerEnum.user, 7);
            public static readonly ErrorType worefilter = new ErrorType("worefilter", InnerEnum.worefilter, 8);

            private static readonly IList<ErrorType> valueList = new List<ErrorType>();

            static ErrorType()
            {
                valueList.Add(chatRoom);
                valueList.Add(group);
                valueList.Add(message);
                valueList.Add(push);
                valueList.Add(sensitiveword);
                valueList.Add(sms);
                valueList.Add(user);
                valueList.Add(worefilter);
            }

            public enum InnerEnum
            {
                chatRoom,
                group,
                message,
                push,
                sensitiveword,
                sms,
                user,
                worefilter
            }

            public readonly InnerEnum innerEnumValue;
            private readonly string nameValue;
            private readonly int ordinalValue;
            private static int nextOrdinal = 0;

            internal int resultCode;

            internal ErrorType(string name, InnerEnum innerEnum, int resultCode)
            {
                this.resultCode = resultCode;
                this.nameValue = name;
                ordinalValue = nextOrdinal++;
                innerEnumValue = innerEnum;
            }
            public int ResutCode
            {
                get
                {
                    return this.resultCode;
                }
            }

            public static IList<ErrorType> values()
            {
                return valueList;
            }

            public int ordinal()
            {
                return ordinalValue;
            }

            public override string ToString()
            {
                return nameValue;
            }

            public static ErrorType valueOf(string name)
            {
                foreach (ErrorType enumInstance in ErrorType.valueList)
                {
                    if (enumInstance.nameValue == name)
                    {
                        return enumInstance;
                    }
                }
                throw new System.ArgumentException(name);
            }
        }
    }
}