using Dapper;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class MessageTemplateRepository : DapperRepository
    {
        private readonly string _connectionString;
        public MessageTemplateRepository(string connectionString) : base(connectionString) 
        {
            
            _connectionString = connectionString;
        }
        // 1. TÜM AKTİF ŞABLONLARI GETİR
        public async Task<IEnumerable<MessageTemplate>> GetAllActiveAsync()
        {
            // Önce Sistem şablonları (True olanlar) üste gelsin, sonra isme göre sıralansın
            string sql = @"
                SELECT 
                    template_id AS TemplateId, 
                    template_name AS TemplateName, 
                    template_content AS TemplateContent, 
                    template_code AS TemplateCode, 
                    is_system AS IsSystem, 
                    is_active AS IsActive 
                FROM message_templates 
                WHERE is_active = true 
                ORDER BY is_system DESC, template_name ASC;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<MessageTemplate>(sql);
            }
        }

        // 2. YENİ ŞABLON EKLE (Sadece müşteri kendi eklerse çalışır)
        public async Task<int> AddAsync(MessageTemplate template)
        {
            // Müşterinin eklediği her şablon zorunlu olarak 'CUSTOM' kodunu ve is_system=false değerini alır. (Güvenlik!)
            string sql = @"
                INSERT INTO message_templates (template_name, template_content, template_code, is_system, is_active) 
                VALUES (@TemplateName, @TemplateContent, 'CUSTOM', false, true) 
                RETURNING template_id;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteScalarAsync<int>(sql, template);
            }
        }

        // 3. ŞABLON GÜNCELLE (Akıllı Güncelleme)
        public async Task UpdateAsync(MessageTemplate template)
        {
            // İŞTE SİHİR BURADA: Eğer is_system=true ise veritabanı template_name'i GÜNCELLEMEZ (CASE WHEN ile koruma)
            // Sadece içeriği (template_content) günceller.
            string sql = @"
                UPDATE message_templates 
                SET 
                    template_name = CASE WHEN is_system = false THEN @TemplateName ELSE template_name END,
                    template_content = @TemplateContent
                WHERE template_id = @TemplateId;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql, template);
            }
        }

        // 4. ŞABLONU SİL (Soft Delete - Sadece Pasife Al)
        public async Task DeleteAsync(int templateId)
        {
            // ÇİFT DİKİŞ GÜVENLİK: Sadece is_system = false olanlar silinebilir!
            string sql = @"
                UPDATE message_templates 
                SET is_active = false 
                WHERE template_id = @TemplateId AND is_system = false;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                int rowsAffected = await connection.ExecuteAsync(sql, new { TemplateId = templateId });

                // Eğer hiçbir satır etkilenmediyse, ya ID yanlıştır ya da adam Sistem Şablonunu silmeye çalışıyordur.
                if (rowsAffected == 0)
                    throw new System.Exception("Bu şablon bir sistem şablonudur veya bulunamadı, silinemez!");
            }
        }
    }
}
