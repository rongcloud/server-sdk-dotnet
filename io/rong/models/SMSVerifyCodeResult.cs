using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace donet.io.rong.models {
		
	/**
	 *  VerifyCode 返回结果
	 */
	public class SMSVerifyCodeResult {
		// 返回码，200 为正常。
		[JsonProperty]
		int code;
		// true 验证成功，false 验证失败。
		[JsonProperty]
		Boolean success;
		// 错误信息。
		[JsonProperty]
		String errorMessage;
		
		public SMSVerifyCodeResult(int code, Boolean success, String errorMessage) {
			this.code = code;
			this.success = success;
			this.errorMessage = errorMessage;
		}
		
		/**
		 * 设置code
		 *
		 */	
		public void setCode(int code) {
			this.code = code;
		}
		
		/**
		 * 获取code
		 *
		 * @return Integer
		 */
		public int getCode() {
			return code;
		}
		
		/**
		 * 设置success
		 *
		 */	
		public void setSuccess(Boolean success) {
			this.success = success;
		}
		
		/**
		 * 获取success
		 *
		 * @return Boolean
		 */
		public Boolean getSuccess() {
			return success;
		}
		
		/**
		 * 设置errorMessage
		 *
		 */	
		public void setErrorMessage(String errorMessage) {
			this.errorMessage = errorMessage;
		}
		
		/**
		 * 获取errorMessage
		 *
		 * @return String
		 */
		public String getErrorMessage() {
			return errorMessage;
		}
		
		public String toString() {
	    	return JsonConvert.SerializeObject(this);
	        }
		}
}
