﻿using dosymep.SimpleServices.PlatformProfiles;

namespace dosymep.SimpleServices {
    /// <summary>
    /// Интерфейс сервиса профилей.
    /// </summary>
    public interface IPlatformProfileService {
        /// <summary>
        /// Профиль пользователя.
        /// </summary>
        IProfileInstance User { get; }
        
        /// <summary>
        /// Профиль системы.
        /// </summary>
        IProfileInstance System { get; }
        
        /// <summary>
        /// Профиль организации 
        /// </summary>
        IProfileInstance Organization { get; }
    }
    
    /// <summary>
    /// Интерфейс предоставляет доступ к настройкам плагинов.
    /// </summary>
    /// <typeparam name="TSpaceProfile">Класс пространства конфигурации.</typeparam>
    public interface IPlatformProfileService<TSpaceProfile> : IPlatformProfileService
        where TSpaceProfile : ProfileSpace {
        /// <summary>
        /// Возвращает экземпляр настроек плагина.
        /// </summary>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <typeparam name="T">Тип настроек плагина.</typeparam>
        /// <returns>Возвращает экземпляр настроек плагина.</returns>
        T GetPluginSettings<T>(string pluginName);

        /// <summary>
        /// Возвращает экземпляр настроек плагина.
        /// </summary>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <param name="settingsName">Наименование настроек.</param>
        /// <typeparam name="T">Тип настроек плагина.</typeparam>
        /// <returns>Возвращает экземпляр настроек плагина.</returns>
        T GetPluginSettings<T>(string pluginName, string settingsName);

        /// <summary>
        /// Сохраняет настройки плагина.
        /// </summary>
        /// <param name="settings">Настройки плагина.</param>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <typeparam name="T">Тип настроек плагина.</typeparam>
        void SavePluginSettings<T>(T settings, string pluginName);

        /// <summary>
        /// Сохраняет настройки плагина.
        /// </summary>
        /// <param name="settings">Настройки плагина.</param>
        /// <param name="pluginName">Наименование плагина.</param>
        /// <param name="settingsName">Наименование настроек.</param>
        /// <typeparam name="T">Тип настроек плагина.</typeparam>
        void SavePluginSettings<T>(T settings, string pluginName, string settingsName);
    }

    /// <summary>
    /// Абстрактный класс настроек пространства профиля.
    /// </summary>
    public abstract class ProfileSpace {
        /// <summary>
        /// Создает экземпляр пространства настроек профиля.
        /// </summary>
        /// <param name="name"></param>
        protected ProfileSpace(string name) {
            Name = name;
        }

        /// <summary>
        /// Пользовательские настройки пространства профиля.
        /// </summary>
        public static UserProfileSpace UserProfileSpace => new UserProfileSpace("User");

        /// <summary>
        /// Системные настройки пространства профиля.
        /// </summary>
        public static SystemProfileSpace SystemProfileSpace => new SystemProfileSpace("System");

        /// <summary>
        /// Организации настройки пространства профиля.
        /// </summary>
        public static OrganizationProfileSpace OrganizationProfileSpace => new OrganizationProfileSpace("Organization");

        /// <summary>
        /// Наименование пространства профиля.
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// Пользовательские настройки пространства профиля.
    /// </summary>
    public sealed class UserProfileSpace : ProfileSpace {
        /// <summary>
        /// Создает экземпляр пользовательского пространства настроек профиля.
        /// </summary>
        /// <param name="name">Наименование профиля.</param>
        internal UserProfileSpace(string name)
            : base(name) {
        }
    }

    /// <summary>
    /// Системные настройки пространства профиля.
    /// </summary>
    public sealed class SystemProfileSpace : ProfileSpace {
        /// <summary>
        /// Создает экземпляр системного пространства настроек профиля.
        /// </summary>
        /// <param name="name">Наименование профиля.</param>
        internal SystemProfileSpace(string name)
            : base(name) {
        }
    }

    /// <summary>
    /// Организации настройки пространства профиля.
    /// </summary>
    public sealed class OrganizationProfileSpace : ProfileSpace {
        /// <summary>
        /// Создает экземпляр организации пространства настроек профиля.
        /// </summary>
        /// <param name="name">Наименование профиля.</param>
        internal OrganizationProfileSpace(string name)
            : base(name) {
        }
    }
}