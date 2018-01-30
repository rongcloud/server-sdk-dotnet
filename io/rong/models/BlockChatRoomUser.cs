using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace donet.io.rong.models {
		
	/**
	 * 聊天室被封禁用户信息。
	 */
	public class BlockChatRoomUser {
		// 聊天室用户Id。
		[JsonProperty]
		String userId;
		// 加入聊天室时间。
		[JsonProperty]
		String time;
		
		public BlockChatRoomUser(String userId, String time) {
			this.userId = userId;
			this.time = time;
		}
		
		/**
		 * 设置userId
		 *
		 */	
		public void setUserId(String userId) {
			this.userId = userId;
		}
		
		/**
		 * 获取userId
		 *
		 * @return String
		 */
		public String getUserId() {
			return userId;
		}
		
		/**
		 * 设置time
		 *
		 */	
		public void setTime(String time) {
			this.time = time;
		}
		
		/**
		 * 获取time
		 *
		 * @return String
		 */
		public String getTime() {
			return time;
		}
		
		public String toString() {
	    	return JsonConvert.SerializeObject(this);
	        }
		}
}
