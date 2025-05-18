Vì lười mỗi lần sửa 1 chút phải repack vào resource.asset khá là rườm rà nên nhờ GPT viết code tạo hộ 1 plugin, sử dụng với Beepinex Il2cpp 6.x

Đặt dll vào thư mục \BepInEx\plugins\ , tạo thư mục ImmortalLife cùng chỗ với dll, hoặc khi mở game plugin sẽ tự tạo thư mục.
Plugin hoạt động sẽ load thay thế các TextAsset trong game nếu có file trùng tên đặt trong thư mục ImmortalLife. Nội dung kết cấu json trong txt vẫn tuân thủ như file gốc để có thể dùng khi muốn pack vào resource.

Các file TextAsset có thể dùng Assetstudio, UBAEA để tìm và trích xuất. 
Lưu ý để tên gốc giống với trong text asset của game, vì dùng UBAEA có khi tên dài hơn thì đổi tên lại cho đúng ví dụ: **Language.txt**.

BTW vì dùng để kiểm tra nhanh trước khi pack vào resource nên có lỗi gì khác lạ mình cũng chịu, chung quy là không có kinh nghiệm.
