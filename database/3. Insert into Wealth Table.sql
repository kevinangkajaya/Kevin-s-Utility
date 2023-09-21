SET @user_id = 1;
SET @created_at = CURRENT_TIMESTAMP();

INSERT INTO wealths (userId, location, sublocation, `active`, `value`, valueinrupiah, createdat)
VALUES
(@user_id, 'BCA', '', TRUE, NULL, 10000000, @created_at),
(@user_id, 'Jenius', 'Bibit Saver', FALSE, NULL, 120, @created_at),
(@user_id, 'OVO', '', TRUE, NULL, 200000, @created_at),
(@user_id, 'Tokopedia', 'Emas', TRUE, NULL, 0, @created_at),
(@user_id, 'Tokocrypto', 'ETH', TRUE, 0.023, 579054.48, @created_at),
(@user_id, 'Tokocrypto', 'Doge', TRUE, 61.232, 58490.95, @created_at),
(@user_id, 'Alfagift', 'Poin', TRUE, 98, 98, @created_at),
(@user_id, 'Indomaret', 'Poinku', TRUE, 55, 55, @created_at)